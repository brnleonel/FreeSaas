using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Infrastructure.UnitOfWork;

namespace FreeSaas.Infrastructure.Repositories
{
    public class IbgeRepositorie : Repository<Ibge>, IIbgeRepositorie
    {
        public IbgeRepositorie(FreeSaasUOW FreeSaasUOW) : base(FreeSaasUOW)
        {
        }
    }
}
