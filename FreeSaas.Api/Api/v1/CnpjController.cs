using Asp.Versioning;
using FreeSaas.Crosscutting.DTOs;
using FreeSaas.Domain.Entities;
using FreeSaas.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace FreeSaas.Api.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class CnpjController : Controller
    {
        private readonly IFactoryService _appFactory;

        public CnpjController(IFactoryService appFactory, IConnectionMultiplexer muxer)
        {
            _appFactory = appFactory;
        }

        [HttpGet("{cnpj}")]
        public CnpjDTO Get(string cnpj)
        {
            var retorno = _appFactory.CnpjService.GetByCnpj(cnpj);
            return retorno;
        }

        [HttpGet]
        public IEnumerable<CnpjDTO> Get()
        {
            return _appFactory.CnpjService.GetAll();
        }
    }
}
