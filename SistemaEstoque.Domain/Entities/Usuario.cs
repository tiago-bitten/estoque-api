using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities
{
    public sealed class Usuario : IdentificadorTenant
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool AcessoBloqueado { get; set; }
        public int PerfilAcessoId { get; set; }
        
        public PerfilAcesso PerfilAcesso { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public List<Movimentacao> Movimentacoes { get; set; } = new();
        public List<AuditoriaEntidade> AuditoriaEntidades { get; set; } = new();
        public List<RegistroUsuarioAcesso> AuditoriaUsuarioAcessos { get; set; } = new();
        public List<RemessaLote> Lotes { get; set; }

        #region Methods

        public void VerifyAcessoBloqueado()
        {
            if (AcessoBloqueado) 
                throw new Exception("Seu acesso está bloqueado, entre em contato com um administrador para regularizar");
        }

        #endregion
    }
}