using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateLote;
using SistemaEstoque.Application.Queries.GetAllLotes;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create([FromBody] CreateLoteCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, int take = 15)
        {
            var query = new GetAllLotesQuery(skip, take);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
