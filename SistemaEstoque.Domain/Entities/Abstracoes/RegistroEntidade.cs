using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Domain.Entities.Abstracoes;

public abstract class RegistroEntidade : IdentificadorTenant
{
    public string Tabela { get; set; }
    public int ItemId { get; set; }
    public DateTime Data { get; set; }
    public ETipoAlteracao Tipo { get; set; }
    public int UsuarioId { get; set; }
    
    public Usuario Usuario { get; set; }
}