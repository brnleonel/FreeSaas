using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Service.Interfaces;

namespace FreeSaas.Service.Services
{
    public class CepService : ICepService
    {
        private readonly IFactoryRepositories _factoryRepositorie;

        public CepService(IFactoryRepositories factoryRepositorie)
        {
            _factoryRepositorie = factoryRepositorie;
        }

        public Cep Add(Cep cep)
        {
            _factoryRepositorie.CepRepositorie.Add(cep);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return cep;
        }

        public bool Delete(Cep cep)
        {
            _factoryRepositorie.CepRepositorie.Remove(cep);
            _factoryRepositorie.FreeSaasUOW.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<Cep> GetAll()
        {
            return _factoryRepositorie.CepRepositorie.GetAll();
        }

        public Cep GetByCode(string code)
        {
            ///Implementar consulta e cadastro
            return _factoryRepositorie.CepRepositorie.Get(code);
        }

        public Cep Update(Cep cep)
        {
            /*
            _factoryRepositorie.CepRepositorie.Update(cep);
            */
            return cep;
        }
    }
}
