using FreeSaas.Crosscutting.DTOs;

namespace FreeSaas.Service.External
{
    public interface IFederalService : IDisposable
    {
        CnpjDTO ConsultaSintegra(string cnpj);
    }
}
