using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaEstoque.Application.Responses;

namespace SistemaEstoque.API.Filters
{
    public class ResponseBaseFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var mensagem = context.HttpContext.Items["MensagemAPI"]?.ToString();

                var apiResponse = new ResponseBase<object>
                {
                    Sucesso = objectResult.StatusCode >= 200 && objectResult.StatusCode < 300,
                    Conteudo = objectResult.StatusCode >= 200 && objectResult.StatusCode < 300 ? objectResult.Value : null,
                    Erros = objectResult.StatusCode >= 400 ? new List<string> { objectResult.Value?.ToString() } : null,
                    Mensagem = objectResult.StatusCode >= 400 ? "Erro geral" : mensagem,
                };

                var pagedResponseType = typeof(IPagedResponse);
                var objectType = objectResult.Value?.GetType();
                if (objectType != null)
                {
                    var isPagedResponse = objectType.GetInterfaces().Any(i => i.Equals(pagedResponseType));
                    if (isPagedResponse)
                    {
                        var totalProperty = objectType.GetProperty("Total");
                        if (totalProperty != null)
                        {
                            apiResponse.Total = (int) totalProperty.GetValue(objectResult.Value);
                            apiResponse.Conteudo = (objectResult.Value as IEnumerable<object>).ToList();
                        }
                    }
                }

                context.Result = new ObjectResult(apiResponse)
                {
                    StatusCode = objectResult.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
