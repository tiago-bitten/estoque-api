namespace SistemaEstoque.Application.Commands.RefreshToken;

public class RefreshTokenResponse
{
    public RefreshTokenResponse(string accessToken, Domain.Entities.RefreshToken refreshToken)
    {
        Token = accessToken;
        RefreshToken = refreshToken.Token;
        Expiration = refreshToken.DataExpiracao;
    }
    
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
}