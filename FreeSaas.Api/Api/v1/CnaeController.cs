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
    public class CnaeController : Controller
    {
        private readonly IFactoryService _appFactory;

        public CnaeController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }

        [HttpGet("{code}")]
        public Cnae Get(int code)
        {
            return _appFactory.CnaeService.GetByCode(code);
        }

        [HttpGet]
        public IEnumerable<Cnae> Get()
        {
            return _appFactory.CnaeService.GetAll();
        }

        [HttpPost]
        public Cnae Post([FromBody] Cnae cnae)
        {
            return _appFactory.CnaeService.Add(cnae);
        }

        [HttpPut]
        public Cnae Put([FromBody] Cnae cnae)
        {
            return _appFactory.CnaeService.Update(cnae);
        }

        [HttpDelete]
        public bool Delete([FromBody] Cnae cnae)
        {
            return _appFactory.CnaeService.Delete(cnae);
        }
    }
}
