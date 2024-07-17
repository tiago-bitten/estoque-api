using SistemaEstoque.Application.DTOs;

namespace SistemaEstoque.Application.Commands.CreateLote
{
    public class CreateLoteResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public int UsuarioRecebimentoId { get; set; }
        public DateTime DataRecebimento { get; set; }
        public IEnumerable<LoteItemDTO> LotesItens { get; set; }
    }
}
