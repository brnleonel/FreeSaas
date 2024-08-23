using FreeSaas.Domain.Interfaces;

namespace FreeSaas.Domain.Entities
{
    public class Cnae : Entity
    {
        public int Codigo { get; set; }

        public required string Descricao { get; set; }
    }
}
