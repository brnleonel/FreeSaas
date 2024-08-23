using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class CboService : ICboService
    {
        private readonly IFactoryRepositories _factoryRepositorie;

        public CboService(IFactoryRepositories factoryRepositorie)
        {
            _factoryRepositorie = factoryRepositorie;
        }

        public Cbo Add(Cbo cbo)
        {
            _factoryRepositorie.CboRepositorie.Add(cbo);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return cbo;
        }

        public bool Delete(Cbo cbo)
        {
            _factoryRepositorie.CboRepositorie.Remove(cbo);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<Cbo> GetAll()
        {
            return _factoryRepositorie.CboRepositorie.GetAll();
        }

        public Cbo GetByCode(string code)
        {
            return _factoryRepositorie.CboRepositorie.Get(code);
        }

        public Cbo Update(Cbo cbo)
        {
            /*
            _factoryRepositorie.CboRepositorie.Update(cbo);
            */
            return cbo;
        }
    }
}
