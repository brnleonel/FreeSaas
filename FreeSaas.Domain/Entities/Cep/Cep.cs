using FreeSaas.Domain.Interfaces;

namespace FreeSaas.Domain.Entities
{
    public class Cep : Entity
    {
        public required string Codigo { get; set; }

        public required string Conteudo { get; set; }
    }
}
