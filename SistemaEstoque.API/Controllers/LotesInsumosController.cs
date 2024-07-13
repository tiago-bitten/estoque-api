using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateLoteInsumo;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesInsumosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LotesInsumosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> CriarLoteInsumo([FromBody] CreateLoteInsumoCommand command)
        {
            var response = await _mediator.Send(command);

            HttpContext.Items["MensagemAPI"] = "Lote de insumo criado";

            return Ok(response);
        }
    }
}
