using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreatePerfilAcesso;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfisAcessosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PerfisAcessosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreatePerfilAcessoComannd command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        //[HttpPost("Criar/PermissaoProduto")]

        //[HttpPost("Criar/PermissaoInsumo")]
    }
}
