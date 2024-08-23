using Asp.Versioning;
using FreeSaas.Crosscutting.DTOs;
using FreeSaas.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace FreeSaas.Api.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class AuthorizationController : ControllerBase
    {
        private readonly IFactoryService _appFactory;

        public AuthorizationController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }

        [HttpPost("Register")]
        public object Register(string mail, string fone)
        {
            return new
            {
                Message = "Funcionalidade não implementada\nLogin padrão data atual ddMMyyyy!"
            };
        }

        [HttpPost("Authenticate")]
        public object Authenticate([FromBody]LoginDTO loginDTO,
                                   [FromServices]SigningCredentials signingConfigurations)
        {
            if (!string.Equals(loginDTO.user, DateTime.Now.ToString("ddMMyyyy"), StringComparison.InvariantCultureIgnoreCase) ||
                !string.Equals(loginDTO.password, DateTime.Now.ToString("ddMMyyyy"), StringComparison.InvariantCultureIgnoreCase))
            {
                return new
                {
                    Message = "Usuario ou senha invalido!"
                };
            }

            var dataCriacao = DateTime.Now;
            var dataExpiracao = DateTime.Now.AddMinutes(10);

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(loginDTO.user, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, loginDTO.user),
                        new Claim("Created", dataCriacao.ToString("yyyy-MM-dd HH:mm:ss")),
                        new Claim("Expiration", dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss")),
                        new Claim("Culture", "pt-BR"),
                        new Claim("IsAutenticado", "1")
                }
            );

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "devcode",
                Audience = "FreeSaas.com/dev",
                SigningCredentials = signingConfigurations,
                Subject = identity,
                NotBefore = DateTime.Now,
                Expires = dataExpiracao.AddMinutes(10)
            });
            var token = handler.WriteToken(securityToken);

            return new
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "Autenticado"
            };
        }
    }
}
