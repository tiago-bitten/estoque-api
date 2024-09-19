using SistemaEstoque.Domain.Entities.Abstracoes;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Estoque : IdentificadorTenant
    {
        public int ItemId { get; set; }
        public ETipoItem Tipo { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
        public int QuantidadeMaxima { get; set; }

        // Referencias para navegação
        public List<Movimentacao> Movimentacoes { get; set; } = new();
        public List<HistoricoEstoque> HistoricoEstoques { get; set; } = new();
        
        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void RemoverQuantidade(int quantidade)
        {
            Quantidade -= quantidade;
        }
    }
}
