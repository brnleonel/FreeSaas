using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Infrastructure.UnitOfWork;

namespace FreeSaas.Infrastructure.Repositories
{
    public class CfopRepositorie : Repository<Cfop>, ICfopRepositorie
    {
        public CfopRepositorie(FreeSaasUOW FreeSaasUOW) : base(FreeSaasUOW)
        {
        }
    }
}
