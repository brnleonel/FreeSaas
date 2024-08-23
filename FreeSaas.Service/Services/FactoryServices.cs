using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.External;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class FactoryServices : IFactoryService
    {
        private readonly IFactoryRepositories _factoryRepositories;
        private readonly IFederalService _federalService;

        private IBancoService? _bancoService;
        private ICboService? _cboService;
        private ICepService? _cepService;
        private ICestService? _cestService;
        private ICfopService? _cfopService;
        private ICnaeService? _cnaeService;
        private IIbgeService? _ibgeService;
        private INcmService? _ncmService;
        private ICnpjService? _cnpjService;

        public FactoryServices(IFactoryRepositories factoryRepositories, IFederalService federalService)
        {
            _factoryRepositories = factoryRepositories;
            _federalService = federalService;
        }
        
        public IBancoService BancoService
        {
            get
            {
                return _bancoService ?? (_bancoService = new BancoService(_factoryRepositories));
            }
        }


        public ICboService CboService
        {
            get
            {
                return _cboService ?? (_cboService = new CboService(_factoryRepositories));
            }
        }

        public ICepService CepService
        {
            get
            {
                return _cepService ?? (_cepService = new CepService(_factoryRepositories));
            }
        }

        public ICestService CestService
        {
            get
            {
                return _cestService ?? (_cestService = new CestService(_factoryRepositories));
            }
        }

        public ICfopService CfopService
        {
            get
            {
                return _cfopService ?? (_cfopService = new CfopService(_factoryRepositories));
            }
        }

        public ICnaeService CnaeService
        {
            get
            {
                return _cnaeService ?? (_cnaeService = new CnaeService(_factoryRepositories));
            }
        }

        public IIbgeService IbgeService
        {
            get
            {
                return _ibgeService ?? (_ibgeService = new IbgeService(_factoryRepositories));
            }
        }

        public INcmService NcmService
        {
            get
            {
                return _ncmService ?? (_ncmService = new NcmService(_factoryRepositories));
            }
        }

        public ICnpjService CnpjService
        {
            get
            {
                return _cnpjService ?? (_cnpjService = new CnpjService(_federalService));
            }
        }

        public void Dispose()
        {
            _bancoService?.Dispose();
            _cboService?.Dispose();
            _cepService?.Dispose();
            _cestService?.Dispose();
            _cfopService?.Dispose();
            _cnaeService?.Dispose();
            _ibgeService?.Dispose();
            _ncmService?.Dispose();
            _cnpjService?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
