namespace SistemaEstoque.Application.DTOs
{
    public class InsumoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVendaReferencia { get; set; }
        public decimal PrecoCustoReferencia { get; set; }
        public CategoriaDTO Categoria { get; set; }
    }
}
