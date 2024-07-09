using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateCategoria;
using SistemaEstoque.Application.Commands.UpdateCategoria;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoriaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
