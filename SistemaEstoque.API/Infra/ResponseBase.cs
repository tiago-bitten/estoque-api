using System.Text.Json.Serialization;
using SistemaEstoque.Shared.Util;

namespace SistemaEstoque.API.Infra;

#region Response Base
public class ResponseBase<T> where T : class
{
    [JsonPropertyName("Success")]
    public bool Success { get; set; }
        
    [JsonPropertyName("Data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }
        
    [JsonPropertyName("Message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }
        
    [JsonPropertyName("Errors")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Errors { get; set; }
        
    [JsonPropertyName("Total")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Total { get; set; }
        
    [JsonPropertyName("Page")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Page { get; set; }
        
    [JsonPropertyName("Size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Size { get; set; }
        
    [JsonPropertyName("HasNext")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasNext { get; set; }
        
    [JsonPropertyName("HasPrevious")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HasPrevious { get; set; }
}
#endregion

#region Success Response
public class ResponseSuccess<T> : ResponseBase<T> where T : class
{
    public ResponseSuccess(T data, string? message = null)
    {
        Success = true;
        Data = data;
        Message = message;
    }
}
#endregion

#region Error Responses
public class ResponseError : ResponseBase<dynamic>
{
    public ResponseError(string message, List<string>? errors = null)
    {
        Success = false;
        Message = message;
        Errors = errors;
    }
}

public class ResponseNotFound : ResponseBase<dynamic>
{
    public ResponseNotFound(string message = "Recurso não encontrado.")
    {
        Success = false;
        Message = message;
    }
}

public class ResponseValidationError : ResponseBase<dynamic>
{
    public ResponseValidationError(List<string> errors)
    {
        Success = false;
        Message = "Erro de validação.";
        Errors = errors;
    }
}
#endregion

#region Paged Response
public class ResponsePaged<T> : ResponseBase<IEnumerable<T>> where T : class
{
    public ResponsePaged(PagedResult<T> pagedResult, string? message = null)
    {
        Success = true;
        Data = pagedResult.Data;
        Total = pagedResult.Total;
        Page = pagedResult.Page;
        Size = pagedResult.Size;
        HasNext = pagedResult.HasNext;
        HasPrevious = pagedResult.HasPrevious;
        Message = message;
    }
}
#endregion

#region Authorization Responses
public class ResponseUnauthorized : ResponseBase<dynamic>
{
    public ResponseUnauthorized(string message = "Não autorizado.")
    {
        Success = false;
        Message = message;
    }
}

public class ResponseForbidden : ResponseBase<dynamic>
{
    public ResponseForbidden(string message = "Acesso proibido.")
    {
        Success = false;
        Message = message;
    }
}
#endregion

#region Created Response
public class ResponseCreated<T> : ResponseBase<T> where T : class
{
    public ResponseCreated(T data, string? message = null)
    {
        Success = true;
        Data = data;
        Message = message ?? "Recurso criado com sucesso.";
    }
}
#endregion