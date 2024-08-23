using Asp.Versioning;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Infrastructure.Repositories;
using FreeSaas.Infrastructure.Seed;
using FreeSaas.Infrastructure.UnitOfWork;
using FreeSaas.Service.External;
using FreeSaas.Service.Interfaces;
using FreeSaas.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

#region Log
ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger<Program>();
builder.Services.AddSingleton<ILogger>(logger);
#endregion

#region Infra
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpLogging(o =>
{
    o.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders |
                      Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestBody |
                      Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders |
                      Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseBody;
});
builder.Services.AddSingleton<IConfiguration>(_ => new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json")
                                                    .Build());
builder.Services.AddScoped<IFactoryService, FactoryServices>();
builder.Services.AddScoped<IFactoryRepositories, FactoryRepositories>();
builder.Services.AddScoped<FreeSaasUOW>();

builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<IFederalService, FederalService>();
builder.Services.AddTransient<ICorreioService, CorreioService>();
#endregion

#region Cache
logger.LogInformation("Iniciando redis");
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(new ConfigurationOptions
{
    EndPoints =
    {
        { "host.docker.internal", 7379 }
    }
}));
builder.Services.AddHttpClient();
logger.LogInformation("Conectado redis");
#endregion

#region Versionamento
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
#endregion

#region Autenticação
var signingConfigurations = new SigningCredentials(new RsaSecurityKey(new RSACryptoServiceProvider(2048).ExportParameters(true)), SecurityAlgorithms.RsaSha256Signature);
builder.Services.AddSingleton(signingConfigurations);
builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(bearerOptions =>
    {
        var paramsValidation = bearerOptions.TokenValidationParameters;
        paramsValidation.IssuerSigningKey = signingConfigurations.Key;
        paramsValidation.ValidAudience = "FreeSaas.com/dev";
        paramsValidation.ValidIssuer = "devcode";
        paramsValidation.ValidateIssuerSigningKey = true;
        paramsValidation.ValidateLifetime = true;
        paramsValidation.ClockSkew = TimeSpan.Zero;
    });

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());
});
#endregion

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "FreeSaas 1.0",
        Description = "FreeSaas Tools api",
        TermsOfService = new Uri("https://github.com/brnleonel/brnleonel"),
        Contact = new OpenApiContact
        {
            Name = "Bruno Leonel",
            Email = "brnleonel10@gmail.com",
            Url = new Uri("https://github.com/brnleonel/brnleonel")
        },
        License = new OpenApiLicense
        {
            Name = "Software developed for study",
            Url = new Uri("https://github.com/brnleonel/brnleonel")
        }
    });
});
#endregion

#region Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
#endregion

#region Controllers
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
#endregion

#region Database Migrate/Seed
logger.LogInformation("Iniciando Migrate");
var _repositoryBR = builder.Services.BuildServiceProvider().GetService<IServiceScopeFactory>().CreateScope().ServiceProvider.GetRequiredService<IFactoryRepositories>();
_repositoryBR.FreeSaasUOW.Database.Migrate();
logger.LogInformation("Iniciando Seed");
FreeSaasSeed.Seed(_repositoryBR);
#endregion

var app = builder.Build();
#region swagger
logger.LogInformation("Iniciando Swagger");
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var apiVersionProvider = app.DescribeApiVersions();
    if (apiVersionProvider == null)
        throw new ArgumentException("Api version not registred");

    foreach (var description in apiVersionProvider)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }

    options.DocExpansion(DocExpansion.List);
});
#endregion

//app.UseHttpsRedirection();
logger.LogInformation("UseCors");
app.UseCors("Default");
logger.LogInformation("UseAuthentication");
app.UseAuthentication();
logger.LogInformation("UseRouting");
app.UseRouting();
logger.LogInformation("UseAuthorization");
app.UseAuthorization();
logger.LogInformation("MapControllers");
app.MapControllers();

logger.LogInformation("Aplicacao iniciada");
app.Run();