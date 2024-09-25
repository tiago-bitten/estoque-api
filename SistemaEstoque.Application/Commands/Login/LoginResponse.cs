using System.Text.Json.Serialization;

namespace SistemaEstoque.Application.Commands.Login;

public class LoginResponse
{
    public LoginResponse(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
    
    [JsonPropertyName("Token")]
    public string Token { get; set; }
    
    [JsonPropertyName("RefreshToken")]
    public string RefreshToken { get; set; }
    
    [JsonPropertyName("LogadoEm")]
    public DateTime LogadoEm => DateTime.Now;
}