using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Infrastructure.UnitOfWork;

namespace FreeSaas.Infrastructure.Repositories
{
    public class CboRepositorie : Repository<Cbo>, ICboRepositorie
    {
        public CboRepositorie(FreeSaasUOW FreeSaasUOW) : base(FreeSaasUOW)
        {
        }
    }
}
