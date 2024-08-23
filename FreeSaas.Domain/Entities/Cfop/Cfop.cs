using FreeSaas.Domain.Interfaces;

namespace FreeSaas.Domain.Entities
{
    public class Cfop : Entity
    {
        public int Codigo { get; set; }
        
        public required string Descricao { get; set; }

        public string? Aplicacao { get; set; }
    }
}
