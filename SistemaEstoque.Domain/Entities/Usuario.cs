using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? PerfilAcessoId { get; set; }
        public bool? AcessoBloqueado { get; set; }
        
        public RefreshToken RefreshToken { get; set; }
        public PerfilAcesso? PerfilAcesso { get; set; }

        public IEnumerable<MovimentacaoProduto?> MovimentacoesProdutos { get; set; }
        public IEnumerable<MovimentacaoInsumo?> MovimentacoesInsumos { get; set; }
        public IEnumerable<LogAlteracao?> LogsAlteracoes { get; set; }
        public IEnumerable<HistoricoUsuarioAcesso?> HistoricosUsuariosAcessos { get; set; }
        public IEnumerable<Lote?> Lotes { get; set; }
    }
}