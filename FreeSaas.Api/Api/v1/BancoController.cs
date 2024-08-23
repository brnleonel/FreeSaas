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
    public class BancoController : ControllerBase
    {
        private readonly IFactoryService _appFactory;

        public BancoController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }        

        [HttpGet("{code}")]
        public Banco Get(string code)
        {
            return _appFactory.BancoService.GetByCode(code);
        }

        [HttpGet]
        public IEnumerable<Banco> Get()
        {
            return _appFactory.BancoService.GetAll();
        }

        [HttpPost]
        public Banco Post([FromBody]Banco banco)
        {
            return _appFactory.BancoService.Add(banco);
        }

        [HttpPut]
        public Banco Put([FromBody] Banco banco)
        {
            return _appFactory.BancoService.Update(banco);
        }

        [HttpDelete]
        public bool Delete([FromBody] Banco banco)
        {
            return _appFactory.BancoService.Delete(banco);
        }
    }
}
