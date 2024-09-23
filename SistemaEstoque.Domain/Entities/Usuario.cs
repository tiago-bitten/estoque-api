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
        public List<RegistroInsercaoRemocaoEntidade> RegistroInsercaoRemocaoEntidades { get; set; } = new();
        public List<RegistroAlteracaoEntidade> RegistroAlteracaoEntidades { get; set; } = new();
        public List<RegistroUsuarioAcesso> HistoricosUsuariosAcessos { get; set; } = new();
        public List<RemessaLote> Lotes { get; set; }
    }
}