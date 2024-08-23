using FreeSaas.Crosscutting.DTOs;
using FreeSaas.Domain.Entities;

namespace FreeSaas.Service.Interfaces
{
    public interface ICestService : IDisposable
    {
        Cest GetByCode(string code);

        IEnumerable<Cest> GetAll();

        Cest GetByNcm(CestFilterDTO filter);

        Cest Add(Cest cest);

        Cest Update(Cest cest);

        bool Delete(Cest cest);
    }
}
