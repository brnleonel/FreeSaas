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
    public class CfopController : ControllerBase
    {
        private readonly IFactoryService _appFactory;

        public CfopController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }

        [HttpGet("{code}")]
        public Cfop Get(int code)
        {
            return _appFactory.CfopService.GetByCode(code);
        }

        [HttpGet]
        public IEnumerable<Cfop> Get()
        {
            return _appFactory.CfopService.GetAll();
        }

        [HttpPost]
        public Cfop Post([FromBody] Cfop cfop)
        {
            return _appFactory.CfopService.Add(cfop);
        }

        [HttpPut]
        public Cfop Put([FromBody] Cfop cfop)
        {
            return _appFactory.CfopService.Update(cfop);
        }

        [HttpDelete]
        public bool Delete([FromBody] Cfop cfop)
        {
            return _appFactory.CfopService.Delete(cfop);
        }
    }
}
