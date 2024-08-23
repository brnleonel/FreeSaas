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
    public class CboController : ControllerBase
    {
        private readonly IFactoryService _appFactory;

        public CboController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }

        [HttpGet("{code}")]
        public Cbo Get(string code)
        {
            return _appFactory.CboService.GetByCode(code);
        }

        [HttpGet]
        public IEnumerable<Cbo> Get()
        {
            return _appFactory.CboService.GetAll();
        }

        [HttpPost]
        public Cbo Post([FromBody] Cbo cbo)
        {
            return _appFactory.CboService.Add(cbo);
        }

        [HttpPut]
        public Cbo Put([FromBody] Cbo cbo)
        {
            return _appFactory.CboService.Update(cbo);
        }

        [HttpDelete]
        public bool Delete([FromBody] Cbo cbo)
        {
            return _appFactory.CboService.Delete(cbo);
        }
    }
}
