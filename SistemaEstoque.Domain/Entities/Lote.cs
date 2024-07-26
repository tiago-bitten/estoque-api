using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Lote : EntidadeBase
    {
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public DateTime DataRecebimento { get; set; }
        public int UsuarioRecebimentoId { get; set; }
        public Usuario UsuarioRecebimento { get; set; }

        public IEnumerable<LoteProduto> LotesProdutos { get; set; }
        public IEnumerable<LoteInsumo> LotesInsumos { get; set; }
    }
}
