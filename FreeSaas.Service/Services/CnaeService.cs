using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class CnaeService : ICnaeService
    {
        private readonly IFactoryRepositories _factoryRepositorie;

        public CnaeService(IFactoryRepositories factoryRepositorie)
        {
            _factoryRepositorie = factoryRepositorie;
        }

        public Cnae Add(Cnae cnae)
        {
            _factoryRepositorie.CnaeRepositorie.Add(cnae);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return cnae;
        }

        public bool Delete(Cnae cnae)
        {
            _factoryRepositorie.CnaeRepositorie.Remove(cnae);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<Cnae> GetAll()
        {
            return _factoryRepositorie.CnaeRepositorie.GetAll();
        }

        public Cnae GetByCode(int code)
        {
            return _factoryRepositorie.CnaeRepositorie.Get(code);
        }

        public Cnae Update(Cnae cnae)
        {
            /*
            _factoryRepositorie.CnaeRepositorie.Update(cnae);
            */
            return cnae;
        }
    }
}
