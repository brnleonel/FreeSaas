using FreeSaas.Domain.Interfaces;

namespace FreeSaas.Domain.Entities
{
    public class Banco : Entity
    {
        public required string Codigo { get; set; }
        
        public required string Descricao { get; set; }

        public string? Site { get; set; }
    }
}
