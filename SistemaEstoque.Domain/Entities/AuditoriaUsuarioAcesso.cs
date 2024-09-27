using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities;

public sealed class AuditoriaUsuarioAcesso : IdentificadorTenant
{
    public AuditoriaUsuarioAcesso(int usuarioId, DateTime dataAcesso, string ipAcesso, string userAgent, bool acessoValido, bool senhaGlobal)
    {
        UsuarioId = usuarioId;
        DataAcesso = dataAcesso;
        IpAcesso = ipAcesso;
        UserAgent = userAgent;
        AcessoValido = acessoValido;
        SenhaGlobal = senhaGlobal;
    }
    
    public AuditoriaUsuarioAcesso(DateTime dataAcesso, string ipAcesso, string userAgent, bool acessoValido, bool senhaGlobal)
    {
        DataAcesso = dataAcesso;
        IpAcesso = ipAcesso;
        UserAgent = userAgent;
        AcessoValido = acessoValido;
        SenhaGlobal = senhaGlobal;
    }
    
    public int? UsuarioId { get; set; }
    public DateTime DataAcesso { get; set; }
    public string IpAcesso { get; set; }
    public string UserAgent { get; set; }
    public bool AcessoValido { get; set; }
    public bool SenhaGlobal { get; set; }

    public Usuario? Usuario { get; set; }
}