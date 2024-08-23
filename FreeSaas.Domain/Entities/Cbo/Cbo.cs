using FreeSaas.Domain.Interfaces;

namespace FreeSaas.Domain.Entities
{
    public class Cbo : Entity
    {
        public required string Codigo { get; set; }

        public required string Descricao { get; set; }

        public string? Aplicacao { get; set; }
    }
}
