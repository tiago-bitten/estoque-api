using MediatR;
using SistemaEstoque.Application.DTOs;

namespace SistemaEstoque.Application.Commands.CreateLote
{
    public class CreateLoteCommand : IRequest<CreateLoteResponse>
    {
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public int FornecedorId { get; set; }
        public int UsuarioRecebimentoId { get; set; }
        public DateTime DataRecebimento { get; set; }
        public IEnumerable<LoteItemDTO> LotesItens { get; set; }
    }
}
