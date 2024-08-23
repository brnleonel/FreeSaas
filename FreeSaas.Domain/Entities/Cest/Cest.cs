using FreeSaas.Domain.Interfaces;

namespace FreeSaas.Domain.Entities
{
    public class Cest : Entity
    {
        public required string Codigo { get; set; }
        
        public required string Ncmsh { get; set; }
        
        public required string Descricao { get; set; }
    }
}
