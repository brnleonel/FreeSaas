using FreeSaas.Domain.Entities;

namespace FreeSaas.Service.Interfaces
{
    public interface ICfopService : IDisposable
    {
        Cfop GetByCode(int code);

        IEnumerable<Cfop> GetAll();

        Cfop Add(Cfop cfop);

        Cfop Update(Cfop cfop);

        bool Delete(Cfop cfop);
    }
}
