using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class Item : IdentificadorTenant
    {
        public ETipoItem Tipo { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? PrecoVendaReferencia { get; set; }
        public decimal? PrecoCustoReferencia { get; set; }
        public int CategoriaId { get; set; }

        // Navegação
        public Categoria Categoria { get; set; }
        public List<Estoque> Estoques { get; set; }
        public List<LoteItem> LoteItems { get; set; }
        public List<Movimentacao> Movimentacoes { get; set; }
    }
}
