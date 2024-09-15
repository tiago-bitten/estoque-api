namespace SistemaEstoque.Domain.Entities.Abstracoes;

public class IdentificadorTenant : IdentificadorBase
{
    public int TenantId { get; set; }
    public Empresa Empresa { get; set; }
}