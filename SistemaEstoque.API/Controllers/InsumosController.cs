using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateInsumo;
using SistemaEstoque.Application.Queries.GetAllInsumos;

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

            HttpContext.Items["MensagemAPI"] = "Insumo criado";

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, int take = 15)
        {
            var query = new GetAllInsumosQuery(skip, take);

            var response = await _mediator.Send(query);

            HttpContext.Items["MensagemAPI"] = "Insumos retornados";

            return Ok(response);
        }
    }
}
