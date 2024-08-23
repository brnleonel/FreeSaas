using FreeSaas.Crosscutting.DTOs;
using FreeSaas.Service.External;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class CnpjService : ICnpjService
    {
        private readonly IFederalService _federalService;

        public CnpjService(IFederalService federalService)
        {
            _federalService = federalService;
        }

        public void Dispose()
        {
            _federalService?.Dispose();
        }

        public IEnumerable<CnpjDTO> GetAll()
        {
            /// Consulta tudo que esta em cache
            throw new NotImplementedException();
        }

        public CnpjDTO GetByCnpj(string cnpj)
        {
            var pessoaJuridica = _federalService.ConsultaSintegra(cnpj);
            return pessoaJuridica;
        }
    }
}
