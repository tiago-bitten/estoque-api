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

public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    [NonAction]
    public IActionResult Success<T>(T? content, string? message, int? total) where T : class
    {
        var responseBase = new  ResponseBase<T>
        {
            Success = true,
            Content = content,
            Message = message,
            Total = total
        };

        return Ok(responseBase);
    }
}