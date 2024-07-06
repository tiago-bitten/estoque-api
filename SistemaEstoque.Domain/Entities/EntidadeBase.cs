namespace SistemaEstoque.Domain.Entities
{
    public abstract class EntidadeBase : Tenant
    {
        public int Id { get; set; }
        public bool? Removido { get; set; }
    }
}
