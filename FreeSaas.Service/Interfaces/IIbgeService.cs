using FreeSaas.Domain.Entities;

namespace FreeSaas.Service.Interfaces
{
    public interface IIbgeService : IDisposable
    {
        Ibge GetByCode(int code);

        IEnumerable<Ibge> GetAll();

        Ibge Add(Ibge ibge);

        Ibge Update(Ibge ibge);

        bool Delete(Ibge ibge);
    }
}
