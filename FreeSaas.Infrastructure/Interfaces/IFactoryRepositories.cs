using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.UnitOfWork;

namespace FreeSaas.Infrastructure.Interfaces
{
    public interface IFactoryRepositories : IDisposable
    {
        FreeSaasUOW FreeSaasUOW { get; }

        IBancoRepositorie BancoRepositorie { get; }

        ICboRepositorie CboRepositorie { get; }

        ICepRepositorie CepRepositorie { get; }

        ICestRepositorie CestRepositorie { get; }

        ICfopRepositorie CfopRepositorie { get; }

        ICnaeRepositorie CnaeRepositorie { get; }

        IIbgeRepositorie IbgeRepositorie { get; }

        INcmRepositorie NcmRepositorie { get; }
    }
}
