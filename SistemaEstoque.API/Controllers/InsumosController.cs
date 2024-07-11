using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateInsumo;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InsumosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreateInsumoCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
