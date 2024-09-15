using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateUsuario;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBaseImp
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioCommand command)
        {
            var response = await _mediator.Send(command);

            HttpContext.Items["MensagemAPI"] = "Usuário criado";

            return Ok(response);
        }
    }
}
