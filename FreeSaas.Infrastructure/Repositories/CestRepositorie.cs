using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Infrastructure.UnitOfWork;

namespace FreeSaas.Infrastructure.Repositories
{
    public class CestRepositorie : Repository<Cest>, ICestRepositorie
    {
        public CestRepositorie(FreeSaasUOW FreeSaasUOW) : base(FreeSaasUOW)
        {
        }
    }
}
