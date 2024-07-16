using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> CriarLote([FromBody] CriarLoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
