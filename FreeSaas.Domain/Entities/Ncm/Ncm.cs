using FreeSaas.Domain.Interfaces;

namespace FreeSaas.Domain.Entities
{
    public class Ncm : Entity
    {
        public int Codigo { get; set; }

        public required string Descricao { get; set; }
    }
}
