using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateFornecedor;
using SistemaEstoque.Application.Queries.GetAllFornecedores;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBaseImp
    {
        private readonly IMediator _mediator;

        public FornecedoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CreateFornecedorCommand command)
        {
            var response = await _mediator.Send(command);

            HttpContext.Items["MensagemAPI"] = "Fornecedor criado";

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, int take = 15)
        {
            var query = new GetAllFornecedoresQuery(skip, take);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
