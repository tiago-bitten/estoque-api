namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class Tenant
    {
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
