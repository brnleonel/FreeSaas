using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Infrastructure.UnitOfWork;

namespace FreeSaas.Infrastructure.Repositories
{
    public class FactoryRepositories : IFactoryRepositories
    {
        private readonly FreeSaasUOW _FreeSaasUOW;

        private IBancoRepositorie _bancoRepositorie;
        private ICboRepositorie _cboRepositorie;
        private ICepRepositorie _cepRepositorie;
        private ICestRepositorie _cestRepositorie;
        private ICfopRepositorie _cfopRepositorie;
        private ICnaeRepositorie _cnaeRepositorie;
        private IIbgeRepositorie _ibgeRepositorie;
        private INcmRepositorie _ncmRepositorie;

        public FactoryRepositories(FreeSaasUOW FreeSaasUOW)
        {
            _FreeSaasUOW = FreeSaasUOW;
        }

        public FreeSaasUOW FreeSaasUOW
        {
            get
            {
                return _FreeSaasUOW;
            }
        }

        public IBancoRepositorie BancoRepositorie
        {
            get
            {
                return _bancoRepositorie ?? (_bancoRepositorie = new BancoRepositorie(_FreeSaasUOW));
            }
        }

        public ICboRepositorie CboRepositorie
        {
            get
            {
                return _cboRepositorie ?? (_cboRepositorie = new CboRepositorie(_FreeSaasUOW));
            }
        }

        public ICepRepositorie CepRepositorie
        {
            get
            {
                return _cepRepositorie ?? (_cepRepositorie = new CepRepositorie(_FreeSaasUOW));
            }
        }

        public ICestRepositorie CestRepositorie
        {
            get
            {
                return _cestRepositorie ?? (_cestRepositorie = new CestRepositorie(_FreeSaasUOW));
            }
        }

        public ICfopRepositorie CfopRepositorie
        {
            get
            {
                return _cfopRepositorie ?? (_cfopRepositorie = new CfopRepositorie(_FreeSaasUOW));
            }
        }

        public ICnaeRepositorie CnaeRepositorie
        {
            get
            {
                return _cnaeRepositorie ?? (_cnaeRepositorie = new CnaeRepositorie(_FreeSaasUOW));
            }
        }

        public IIbgeRepositorie IbgeRepositorie
        {
            get
            {
                return _ibgeRepositorie ?? (_ibgeRepositorie = new IbgeRepositorie(_FreeSaasUOW));
            }
        }

        public INcmRepositorie NcmRepositorie
        {
            get
            {
                return _ncmRepositorie ?? (_ncmRepositorie = new NcmRepositorie(_FreeSaasUOW));
            }
        }

        public void Dispose()
        {
            _bancoRepositorie?.Dispose();
            _cboRepositorie?.Dispose();
            _cepRepositorie?.Dispose();
            _cestRepositorie?.Dispose();
            _cfopRepositorie?.Dispose();
            _cnaeRepositorie?.Dispose();
            _ibgeRepositorie?.Dispose();
            _ncmRepositorie?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
