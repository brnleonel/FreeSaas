using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class IbgeService : IIbgeService
    {
        private readonly IFactoryRepositories _factoryRepositorie;

        public IbgeService(IFactoryRepositories factoryRepositorie)
        {
            _factoryRepositorie = factoryRepositorie;
        }

        public Ibge Add(Ibge ibge)
        {
            _factoryRepositorie.IbgeRepositorie.Add(ibge);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return ibge;
        }

        public bool Delete(Ibge ibge)
        {
            _factoryRepositorie.IbgeRepositorie.Remove(ibge);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<Ibge> GetAll()
        {
            return _factoryRepositorie.IbgeRepositorie.GetAll();
        }

        public Ibge GetByCode(int code)
        {
            return _factoryRepositorie.IbgeRepositorie.Get(code);
        }

        public Ibge Update(Ibge ibge)
        {
            /*
            _factoryRepositorie.IbgeRepositorie.Update(ibge);
            */
            return ibge;
        }
    }
}
