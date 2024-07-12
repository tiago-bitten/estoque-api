using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateCategoria;
using SistemaEstoque.Application.Commands.UpdateCategoria;
using SistemaEstoque.Application.Queries.GetAllCategorias;

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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, int take = 15)
        {
            HttpContext.Items["MensagemAPI"] = "Listagem de categorias";

            var query = new GetAllCategoriasQuery(skip, take);
            
            var response = await _mediator.Send(query);
            
            return Ok(response);
        }
    }
}
