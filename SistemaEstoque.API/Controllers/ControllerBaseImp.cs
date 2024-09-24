using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.API.Infra;
using SistemaEstoque.Shared.Util;

namespace SistemaEstoque.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ControllerBaseImp : ControllerBase
    {
        #region Constants
        private const string FallbackSuccessMessage = "Operação concluída com sucesso";
        private const string FallbackErrorMessage = "Ocorreu um erro ao processar a solicitação";
        #endregion
        
        #region Success Methods

        [NonAction]
        public IActionResult Success<T>(T? content = null, string? message = null) where T : class
        {
            var responseBase = new ResponseSuccess<T>(content ?? null!, message ?? FallbackSuccessMessage);
            return Ok(responseBase);
        }

        [NonAction]
        public IActionResult SuccessPaged<T>(PagedResult<T> pagedResult, string? message = null) where T : class
        {
            var responsePaged = new ResponsePaged<T>(pagedResult, message);
            return Ok(responsePaged);
        }

        #endregion

        #region Created Method

        [NonAction]
        public IActionResult Created<T>(T content, string? message = null) where T : class
        {
            var responseCreated = new ResponseCreated<T>(content, message);
            return CreatedAtAction(nameof(Created), responseCreated);
        }

        #endregion

        #region Error Methods

        [NonAction]
        public IActionResult Error(string? message = null, List<string>? errors = null)
        {
            var responseError = new ResponseError(message ?? FallbackErrorMessage, errors);
            return BadRequest(responseError);
        }

        [NonAction]
        public IActionResult ValidationError(List<string> errors)
        {
            var responseValidationError = new ResponseValidationError(errors);
            return BadRequest(responseValidationError);
        }

        #endregion

        #region NotFound/Unauthorized/Forbidden Methods

        [NonAction]
        public IActionResult NotFoundResponse(string? message = null)
        {
            var responseNotFound = new ResponseNotFound(message);
            return NotFound(responseNotFound);
        }

        [NonAction]
        public IActionResult UnauthorizedResponse(string? message = null)
        {
            var responseUnauthorized = new ResponseUnauthorized(message);
            return Unauthorized(responseUnauthorized);
        }

        [NonAction]
        public IActionResult ForbiddenResponse(string? message)
        {
            //var responseForbidden = new ResponseForbidden(message);
            return Forbid(message ?? "Acesso proibido.");
        }

        #endregion
    }
}
