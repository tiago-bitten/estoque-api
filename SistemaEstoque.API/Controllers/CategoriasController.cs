using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateCategoria;
using SistemaEstoque.Application.Commands.UpdateCategoria;
using SistemaEstoque.Application.Queries.GetAllCategorias;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriasController : ControllerBaseImp
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

            HttpContext.Items["MensagemAPI"] = "Categoria criada";

            return Ok(response);
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoriaCommand command)
        {
            var response = await _mediator.Send(command);

            HttpContext.Items["MensagemAPI"] = "Categoria atualizada";

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, int take = 15)
        {

            var query = new GetAllCategoriasQuery(skip, take);
            
            var response = await _mediator.Send(query);

            HttpContext.Items["MensagemAPI"] = "Categorias retornadas";
            
            return Ok(response);
        }
    }
}
