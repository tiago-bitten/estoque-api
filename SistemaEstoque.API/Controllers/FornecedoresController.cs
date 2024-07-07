using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateFornecedor;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FornecedoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreateFornecedorCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
