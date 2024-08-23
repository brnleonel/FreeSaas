using Asp.Versioning;
using FreeSaas.Domain.Entities;
using FreeSaas.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeSaas.Api.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class CepController : ControllerBase
    {
        private readonly IFactoryService _appFactory;

        public CepController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }

        [HttpGet("{code}")]
        public Cep Get(string code)
        {
            return _appFactory.CepService.GetByCode(code);
        }

        [HttpGet]
        public IEnumerable<Cep> Get()
        {
            return _appFactory.CepService.GetAll();
        }
    }
}
