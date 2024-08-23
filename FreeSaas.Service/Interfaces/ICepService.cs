using FreeSaas.Domain.Entities;

namespace FreeSaas.Service.Interfaces
{
    public interface ICepService : IDisposable
    {
        Cep GetByCode(string code);

        IEnumerable<Cep> GetAll();

        Cep Add(Cep cep);

        Cep Update(Cep cep);

        bool Delete(Cep cep);
    }
}
