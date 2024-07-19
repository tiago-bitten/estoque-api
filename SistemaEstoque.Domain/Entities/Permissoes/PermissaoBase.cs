namespace SistemaEstoque.Domain.Entities.Permissoes
{
    public abstract class PermissaoBase : EntidadeBase
    {
        public bool Visualizar { get; set; }
        public bool Criar { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
    }
}
