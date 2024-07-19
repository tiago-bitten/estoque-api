using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Criar(/*[FromBody] CreatePerfilAcessoCommand command*/)
        {
            //var reponse = await _mediator.Send(command)

            return Ok();
        }

        //[HttpPost("Criar/PermissaoProduto")]

        //[HttpPost("Criar/PermissaoInsumo")]
    }
}
