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
    public class NcmController : ControllerBase
    {
        private readonly IFactoryService _appFactory;

        public NcmController(IFactoryService appFactory)
        {
            _appFactory = appFactory;
        }

        [HttpGet("{code}")]
        public Ncm Get(int code)
        {
            return _appFactory.NcmService.GetByCode(code);
        }
        
        [HttpGet]
        public IEnumerable<Ncm> Get()
        {
            return _appFactory.NcmService.GetAll();
        }

        [HttpPost]
        public Ncm Post([FromBody] Ncm ncm)
        {
            return _appFactory.NcmService.Add(ncm);
        }

        [HttpPut]
        public Ncm Put([FromBody] Ncm ncm)
        {
            return _appFactory.NcmService.Update(ncm);
        }

        [HttpDelete]
        public bool Delete([FromBody] Ncm ncm)
        {
            return _appFactory.NcmService.Delete(ncm);
        }
    }
}
