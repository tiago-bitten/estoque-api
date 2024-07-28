using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities;

public class RefreshToken : EntidadeBase
{
    public string Token { get; set; }
    public int UsuarioId { get; set; }
    public DateTime ExpiraEm { get; set; }
    public bool IsRevogado { get; set; }
    public DateTime UltimaGeracao { get; set; }
    
    public Usuario Usuario { get; set; }
}