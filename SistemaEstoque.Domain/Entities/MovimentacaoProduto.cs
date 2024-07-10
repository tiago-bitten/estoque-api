using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class MovimentacaoProduto : EntidadeBase
    {
        public ETipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public decimal PrecoUnitarioVenda { get; set; }
        public decimal PrecoUnitarioCusto { get; set; }
        public EOrigemMovimentacao Origem { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int LoteId { get; set; }
        public LoteProduto LoteProduto { get; set; }

        public decimal ValorTotalVenda => Quantidade * PrecoUnitarioVenda;
        public decimal ValorTotalCustos => Quantidade * PrecoUnitarioCusto;
    }
}
