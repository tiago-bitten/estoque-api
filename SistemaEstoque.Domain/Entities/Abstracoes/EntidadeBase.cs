namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class EntidadeBase : Tenant
    {
        public int Id { get; set; }
        public bool? Removido { get; set; }
    }
}
