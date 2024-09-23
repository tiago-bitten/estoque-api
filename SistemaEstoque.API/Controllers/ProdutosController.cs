using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateProduto;
using SistemaEstoque.Application.Queries.GetAllProdutos;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBaseImp
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create([FromBody] CreateProdutoCommand command)
        {
            var response = await _mediator.Send(command);

            HttpContext.Items["MensagemAPI"] = "Produto criado";

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip, int take)
        {
            var query = new GetAllProdutosQuery(skip, take);

            var response = await _mediator.Send(query);

            HttpContext.Items["MensagemAPI"] = "Items retornados";
            
            return Ok(response);
        }
    }
}
