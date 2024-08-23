using FreeSaas.Domain.Entities;

namespace FreeSaas.Service.Interfaces
{
    public interface ICnaeService : IDisposable
    {
        Cnae GetByCode(int code);

        IEnumerable<Cnae> GetAll();

        Cnae Add(Cnae cnae);

        Cnae Update(Cnae cnae);

        bool Delete(Cnae cnae);
    }
}
