using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateEstoque;
using SistemaEstoque.Application.Queries.GetAllEstoquesProdutos;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquesProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoquesProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreateEstoqueProdutoCommand command)
        {
            var response = await _mediator.Send(command);

            HttpContext.Items["MensagemAPI"] = "Estoque criado";

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] int skip = 0, int take = 15)
        {
            var query = new GetAllEstoquesProdutosQuery(skip, take);

            var response = await _mediator.Send(query);

            HttpContext.Items["MensagemAPI"] = "Estoques de produtos retornados";

            return Ok(response);
        }
    }
}
