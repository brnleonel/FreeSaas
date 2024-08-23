using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class CfopService : ICfopService
    {
        private readonly IFactoryRepositories _factoryRepositorie;

        public CfopService(IFactoryRepositories factoryRepositorie)
        {
            _factoryRepositorie = factoryRepositorie;
        }

        public Cfop Add(Cfop cfop)
        {
            _factoryRepositorie.CfopRepositorie.Add(cfop);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return cfop;
        }

        public bool Delete(Cfop cfop)
        {
            _factoryRepositorie.CfopRepositorie.Remove(cfop);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<Cfop> GetAll()
        {
            return _factoryRepositorie.CfopRepositorie.GetAll();
        }

        public Cfop GetByCode(int code)
        {
            return _factoryRepositorie.CfopRepositorie.Get(code);
        }

        public Cfop Update(Cfop cfop)
        {
            /*
            _factoryRepositorie.CfopRepositorie.Update(cfop);
            */
            return cfop;
        }
    }
}
