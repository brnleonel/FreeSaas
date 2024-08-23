using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using FreeSaas.Infrastructure.UnitOfWork;

namespace FreeSaas.Infrastructure.Repositories
{
    public class BancoRepositorie : Repository<Banco>, IBancoRepositorie
    {
        public BancoRepositorie(FreeSaasUOW FreeSaasUOW) : base(FreeSaasUOW)
        {
        }
    }
}
