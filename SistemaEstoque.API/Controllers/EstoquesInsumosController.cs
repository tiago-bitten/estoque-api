using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateEstoqueInsumo;
using SistemaEstoque.Application.Queries.GetAllEstoquesInsumos;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquesInsumosController : ControllerBaseImp
    {
        private readonly IMediator _mediator;

        public EstoquesInsumosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreateEstoqueInsumoCommand command)
        {
            var response = await _mediator.Send(command);

            HttpContext.Items["MensagemAPI"] = "Estoque insumo criado";

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, int take = 15)
        {
            var query = new GetAllEstoquesInsumosQuery(skip, take);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
