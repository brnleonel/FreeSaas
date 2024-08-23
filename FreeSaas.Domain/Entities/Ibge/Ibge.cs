using FreeSaas.Domain.Interfaces;

namespace FreeSaas.Domain.Entities
{
    public class Ibge : Entity
    {
        public int Codigo { get; set; }

        public required string Descricao { get; set; }
    }
}
