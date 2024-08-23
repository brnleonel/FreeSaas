using FreeSaas.Domain.Entities;

namespace FreeSaas.Service.Interfaces
{
    public interface IBancoService : IDisposable
    {
        Banco GetByCode(string code);

        IEnumerable<Banco> GetAll();

        Banco Add(Banco banco);

        Banco Update(Banco banco);

        bool Delete(Banco banco);
    }
}
