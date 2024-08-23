using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class NcmService : INcmService
    {
        private readonly IFactoryRepositories _factoryRepositorie;

        public NcmService(IFactoryRepositories factoryRepositorie)
        {
            _factoryRepositorie = factoryRepositorie;
        }

        public Ncm Add(Ncm ncm)
        {
            _factoryRepositorie.NcmRepositorie.Add(ncm);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return ncm;
        }

        public bool Delete(Ncm ncm)
        {
            _factoryRepositorie.NcmRepositorie.Remove(ncm);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<Ncm> GetAll()
        {
            return _factoryRepositorie.NcmRepositorie.GetAll();
        }

        public Ncm GetByCode(int code)
        {
            return _factoryRepositorie.NcmRepositorie.Get(code);
        }

        public Ncm Update(Ncm ncm)
        {
            /*
            _factoryRepositorie.NcmRepositorie.Update(ncm);
            */
            return ncm;
        }
    }
}
