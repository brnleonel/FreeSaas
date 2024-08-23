using FreeSaas.Crosscutting.DTOs;
using Newtonsoft.Json;

namespace FreeSaas.Service.External
{
    public class FederalService : IFederalService
    {
        private readonly ICacheService _cacheService;
        private readonly string federalUrlService = "https://www.receitaws.com.br/v1/cnpj";

        public FederalService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public CnpjDTO ConsultaSintegra(string cnpj)
        {
            CacheValue cache = _cacheService.FindCache(cnpj);
            if (cache.Exists)
                return JsonConvert.DeserializeObject<CnpjDTO>(cache.ValueString);

            var rr = ConsultaOnline(cnpj).Result;

            _cacheService.SetCacheString(cnpj, JsonConvert.SerializeObject(rr));

            return rr;
        }

        private async Task<CnpjDTO> ConsultaOnline(string cnpj)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{federalUrlService}/{cnpj}");
                var rs = await response.Content.ReadAsStringAsync();
                var pj = JsonConvert.DeserializeObject<CnpjDTO>(rs);
                return pj;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
