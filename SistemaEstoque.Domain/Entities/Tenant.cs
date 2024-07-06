namespace SistemaEstoque.Domain.Entities
{
    public class Tenant
    {
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
