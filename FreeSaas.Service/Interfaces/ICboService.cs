using FreeSaas.Domain.Entities;

namespace FreeSaas.Service.Interfaces
{
    public interface ICboService : IDisposable
    {
        Cbo GetByCode(string code);

        IEnumerable<Cbo> GetAll();

        Cbo Add(Cbo cbo);

        Cbo Update(Cbo cbo);

        bool Delete(Cbo cbo);
    }
}
