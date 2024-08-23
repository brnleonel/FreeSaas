using FreeSaas.Domain.Entities;

namespace FreeSaas.Service.Interfaces
{
    public interface INcmService : IDisposable
    {
        Ncm GetByCode(int code);

        IEnumerable<Ncm> GetAll();

        Ncm Add(Ncm ncm);

        Ncm Update(Ncm ncm);

        bool Delete(Ncm ncm);
    }
}
