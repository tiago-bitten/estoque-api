using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateLote;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LotesProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreateLoteProdutoCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
