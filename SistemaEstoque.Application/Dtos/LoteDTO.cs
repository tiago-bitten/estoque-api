namespace SistemaEstoque.Application.DTOs
{
    public class LoteDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public int UsuarioRecebimentoId { get; set; }
        public DateTime DataRecebimento { get; set; }
        public List<LoteProdutoDTO> LotesProdutos { get; set; }
        public List<LoteInsumoDTO> LotesInsumos { get; set; }
    }
}
