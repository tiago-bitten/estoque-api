namespace SistemaEstoque.Application.Commands.RefreshToken;

public class RefreshTokenResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
}