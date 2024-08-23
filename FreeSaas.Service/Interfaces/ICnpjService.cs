using FreeSaas.Crosscutting.DTOs;
using FreeSaas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSaas.Service.Interfaces
{
    public interface ICnpjService : IDisposable
    {
        CnpjDTO GetByCnpj(string cnpj);

        IEnumerable<CnpjDTO> GetAll();
    }
}
