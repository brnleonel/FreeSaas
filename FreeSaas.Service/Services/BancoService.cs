using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class BancoService : IBancoService
    {
        private readonly IFactoryRepositories _factoryRepositorie;

        public BancoService(IFactoryRepositories factoryRepositorie)
        {
            _factoryRepositorie = factoryRepositorie;
        }

        public Banco Add(Banco banco)
        {
            _factoryRepositorie.BancoRepositorie.Add(banco);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return banco;
        }

        public bool Delete(Banco banco)
        {
            _factoryRepositorie.BancoRepositorie.Remove(banco);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _factoryRepositorie.FreeSaasUOW.Dispose();
        }

        public Banco GetByCode(string code)
        {
            return _factoryRepositorie.BancoRepositorie.Get(code);
        }

        public IEnumerable<Banco> GetAll()
        {
            return _factoryRepositorie.BancoRepositorie.GetAll();
        }

        public Banco Update(Banco banco)
        {
            var oldPersisted = _factoryRepositorie.BancoRepositorie.Get(banco.Codigo);
            _factoryRepositorie.BancoRepositorie.Merge(oldPersisted, banco);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();           
            return banco;
        }
    }
}
