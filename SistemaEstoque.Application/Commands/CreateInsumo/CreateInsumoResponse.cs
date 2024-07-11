namespace SistemaEstoque.Application.Commands.CreateInsumo
{
    public class CreateInsumoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? PrecoCustoReferencia { get; set; }
        public decimal? PrecoVendaReferencia { get; set; }
        public int? CategoriaId { get; set; }
    }
}
