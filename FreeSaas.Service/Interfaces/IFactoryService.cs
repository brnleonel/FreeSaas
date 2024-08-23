namespace FreeSaas.Service.Interfaces
{
    public interface IFactoryService : IDisposable
    {
        IBancoService BancoService { get; }

        ICboService CboService { get; }

        ICepService CepService { get; }

        ICestService CestService { get; }

        ICfopService CfopService { get; }

        ICnaeService CnaeService { get; }

        IIbgeService IbgeService { get; }

        INcmService NcmService { get; }

        ICnpjService CnpjService { get; }
    }
}
