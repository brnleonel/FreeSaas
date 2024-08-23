using FreeSaas.Crosscutting.DTOs;
using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class CestService : ICestService
    {
        private readonly IFactoryRepositories _factoryRepositorie;

        public CestService(IFactoryRepositories factoryRepositorie)
        {
            _factoryRepositorie = factoryRepositorie;
        }

        public Cest Add(Cest cest)
        {
            _factoryRepositorie.CestRepositorie.Add(cest);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return cest;
        }

        public bool Delete(Cest cest)
        {
            _factoryRepositorie.CestRepositorie.Remove(cest);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<Cest> GetAll()
        {            
            return _factoryRepositorie.CestRepositorie.GetAll();
        }

        public Cest GetByCode(string code)
        {
            return _factoryRepositorie.CestRepositorie.Get(code);
        }

        public Cest GetByNcm(CestFilterDTO filter)
        {
            throw new NotImplementedException();
        }

        public Cest Update(Cest cest)
        {
            /*
           _factoryRepositorie.CestRepositorie.Update(cest);
           */
            return cest;
        }
    }
}
