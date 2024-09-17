using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Usuario : IdentificadorTenant
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int PerfilAcessoId { get; set; }
        public bool AcessoBloqueado { get; set; }
        
        public RefreshToken RefreshToken { get; set; }
        public PerfilAcesso PerfilAcesso { get; set; }

        public List<Movimentacao> Movimentacoes { get; set; } = new();
        public List<LogAlteracao> HistoricoAlteracoes { get; set; } = new();
        public List<HistoricoUsuarioAcesso> HistoricosUsuariosAcessos { get; set; } = new();
        public List<Lote> Lotes { get; set; }
    }
}