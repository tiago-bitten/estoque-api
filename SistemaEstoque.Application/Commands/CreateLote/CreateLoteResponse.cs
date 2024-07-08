namespace SistemaEstoque.Application.Commands.CreateLote
{
    public class CreateLoteResponse
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }
    }
}
