namespace SistemaEstoque.Domain.Entities
{
    public abstract class Lote : EntidadeBase
    {
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
