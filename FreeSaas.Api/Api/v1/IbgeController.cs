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
    public class IbgeController : ControllerBase
    {
        private readonly IFactoryService _appFactory;

        public IbgeController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }

        [HttpGet("{code}")]
        public Ibge Get(int code)
        {
            return _appFactory.IbgeService.GetByCode(code);
        }

        [HttpGet]
        public IEnumerable<Ibge> Get()
        {
            return _appFactory.IbgeService.GetAll();
        }

        [HttpPost]
        public Ibge Post([FromBody] Ibge ibge)
        {
            return _appFactory.IbgeService.Add(ibge);
        }

        [HttpPut]
        public Ibge Put([FromBody] Ibge ibge)
        {
            return _appFactory.IbgeService.Update(ibge);
        }

        [HttpDelete]
        public bool Delete([FromBody] Ibge ibge)
        {
            return _appFactory.IbgeService.Delete(ibge);
        }
    }
}
