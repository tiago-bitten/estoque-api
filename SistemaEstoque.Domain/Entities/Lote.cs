using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Lote : IdentificadorTenant
    {
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public int FornecedorId { get; set; }
        public DateTime DataRecebimento { get; set; }
        public int UsuarioRecebimentoId { get; set; }
        
        public Fornecedor Fornecedor { get; set; }
        public Usuario UsuarioRecebimento { get; set; }
        public List<LoteItem> LoteItems { get; set; } = new();
    }
}
