using Asp.Versioning;
using FreeSaas.Crosscutting.DTOs;
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
    public class CestController : ControllerBase
    {
        private readonly IFactoryService _appFactory;

        public CestController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }

        [HttpGet("{code}")]
        public Cest Get(string code)
        {
            return _appFactory.CestService.GetByCode(code);
        }

        /*
        [HttpGet]
        public Cest Get([FromBody]CestFilterDTO filter)
        {
            return _appFactory.CestService.GetByNcm(filter);
        }
        */

        [HttpGet]
        public IEnumerable<Cest> Get()
        {
            return _appFactory.CestService.GetAll();
        }

        [HttpPost]
        public Cest Post([FromBody] Cest cest)
        {
            return _appFactory.CestService.Add(cest);
        }

        [HttpPut]
        public Cest Put([FromBody] Cest cest)
        {
            return _appFactory.CestService.Update(cest);
        }

        [HttpDelete]
        public bool Delete([FromBody] Cest cest)
        {
            return _appFactory.CestService.Delete(cest);
        }
    }
}
