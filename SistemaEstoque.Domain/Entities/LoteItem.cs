using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class LoteItem : IdentificadorTenant
    {
        public int ItemId { get; set; }
        public ETipoItem Tipo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioCompra { get; set; }
        public decimal PrecoUnitarioVenda { get; set; }
        public int LoteId { get; set; }
        
        public Lote Lote { get; set; }
    }
}
