using Asp.Versioning;
using FreeSaas.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeSaas.Api.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class CorreioController : Controller
    {
        private readonly IFactoryService _appFactory;

        public CorreioController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }
    }
}
