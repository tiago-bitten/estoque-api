using MediatR;

namespace SistemaEstoque.Application.Commands.CreateLote
{
    public class CreateLoteCommand : IRequest<CreateLoteResponse>
    {
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }

        public decimal PrecoUnitarioVenda { get; set; }
        public decimal PrecoUnitarioCusto { get; set; }
    }
}
