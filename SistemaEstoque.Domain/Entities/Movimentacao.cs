using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Movimentacao : IdentificadorTenant
    {
        public int ItemId { get; set; }
        public ETipoItem TipoItem { get; set; }
        public ETipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public decimal PrecoUnitarioVenda { get; set; }
        public decimal PrecoUnitarioCusto { get; set; }
        public EOrigemMovimentacao Origem { get; set; }
        public int UsuarioId { get; set; }
        public int LoteItemId { get; set; }
        public int EstoqueId { get; set; }
        
        public LoteItem LoteItem { get; set; }
        public Usuario Usuario { get; set; }
        public Estoque Estoque { get; set; }

        public decimal ValorTotalVenda => Quantidade * PrecoUnitarioVenda;
        public decimal ValorTotalCustos => Quantidade * PrecoUnitarioCusto;
    }
}
