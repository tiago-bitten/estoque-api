using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateEstoque;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoquesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreateEstoqueCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
