namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class Item : EntidadeBase
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? PrecoVendaReferencia { get; set; }
        public decimal? PrecoCustoReferencia { get; set; }
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
