using MediatR;

namespace SistemaEstoque.Application.Commands.CreateLoteInsumo
{
    public class CreateLoteInsumoCommand : IRequest<CreateLoteInsumoResponse>
    {
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public int InsumoId { get; set; }
        public int FornecedorId { get; set; }

        public decimal PrecoUnitarioVenda { get; set; }
        public decimal PrecoUnitarioCusto { get; set; }
    }
}
