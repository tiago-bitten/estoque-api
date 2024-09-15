using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaEstoque.API.Controllers;

public class ResponseBase<T> where T : class
{
    [JsonPropertyName("Content")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Content { get; init; }
    
    [JsonPropertyName("Success")]
    public bool Success { get; init; }
    
    [JsonPropertyName("Message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; init; }
    
    [JsonPropertyName("Errors")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? Errors { get; init; }
    
    [JsonPropertyName("Total")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Total { get; init; }
}

[ApiController]
[Route("api/[controller]")]
public class ControllerBaseImp : ControllerBase
{
    private const string FallbackSuccessMessage = "Operação concluída com sucesso";
    private const string FallbackErrorMessage = "Ocorreu um erro ao processar a solicitação";
    
    [NonAction]
    public IActionResult Success<T>(T? content, int? total, string? message) where T : class
    {
        var responseBase = new  ResponseBase<T>
        {
            Success = true,
            Content = content,
            Message = message ?? FallbackSuccessMessage,
            Total = total
        };

        return Ok(responseBase);
    }
    
    [NonAction]
    public IActionResult Error(string? message, string[] errors)
    {
        var responseBase = new ResponseBase<dynamic>
        {
            Success = false,
            Message = message ?? FallbackErrorMessage,
            Errors = errors
        };

        return BadRequest(responseBase);
    }
}