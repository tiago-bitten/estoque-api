namespace SistemaEstoque.Application.DTOs
{
    public class EstoqueInsumoDTO
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }
        public InsumoDTO Insumo { get; set; }
    }
}
