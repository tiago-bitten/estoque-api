namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class PermissaoBase : IdentificadorTenant
    {
        public int PerfilAcessoId { get; set; }
        public bool Visualizar { get; set; }
        public bool Criar { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        
        // Navegação
        public PerfilAcesso PerfilAcesso { get; set; }
    }
}
