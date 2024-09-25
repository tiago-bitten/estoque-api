using System.Security.Cryptography;
using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Entities;

public class RefreshToken : IdentificadorTenant
{
    public RefreshToken(string token, Usuario usuario, int tenantId, DateTime dataExpiracao)
    {
        Token = token;
        Usuario = usuario;
        TenantId = tenantId;
        DataExpiracao = dataExpiracao;
    }
    
    public string Token { get; set; }
    public int UsuarioId { get; set; }
    public DateTime DataExpiracao { get; set; }
    public bool Revogado { get; set; }
    public DateTime? DataRevogado { get; set; }
    
    public Usuario Usuario { get; set; }

    public void Revoke()
    {
        Revogado = false;
        DataRevogado = DateTime.Now;
    }
    
    public bool TokenValido => DataExpiracao >= DateTime.UtcNow && !Revogado && DataRevogado is null;

    public static RefreshToken GenerateRefreshToken(Usuario usuario)
    {
        var token = GenerateSecureToken();
        var dataExpiracao = DateTime.UtcNow;
        
        return new RefreshToken(token, usuario, usuario.TenantId, dataExpiracao);
    }
    
    private static string GenerateSecureToken()
    {
        var random = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(random);
        return Convert.ToBase64String(random);
    }
}