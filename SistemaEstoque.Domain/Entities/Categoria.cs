using System.Text.Json.Serialization;

namespace SistemaEstoque.Domain.Entities
{
    public class Categoria : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<Produto?> Produtos { get; set; }
    }
}
