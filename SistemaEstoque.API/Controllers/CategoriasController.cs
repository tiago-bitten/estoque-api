using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateCategoria;
using SistemaEstoque.Application.Commands.UpdateCategoria;
using SistemaEstoque.Application.Queries.GetAllCategorias;

namespace SistemaEstoque.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class CategoriasController : ControllerBaseImp
    {
        private readonly IMediator _mediator;

        public CategoriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [HttpPost("Criar")]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaCommand command)
        {
            if (!ModelState.IsValid)
                return ValidationError(ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList());

            var response = await _mediator.Send(command);

            if (response == null)
                return Error("Erro ao criar a categoria");

            return Created(response);
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoriaCommand command)
        {
            if (!ModelState.IsValid)
                return ValidationError(ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList());

            var response = await _mediator.Send(command);

            if (response == null)
                return Error("Erro ao atualizar a categoria");

            return Success(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, int take = 15)
        {
            var query = new GetAllCategoriasQuery(skip, take);
            var response = await _mediator.Send(query);

            return SuccessPaged(response, "Categorias retornadas com sucesso");
        }
    }
}
