using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.CreateEmpresa;
using System.Runtime.CompilerServices;

namespace SistemaEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBaseImp
    {
        private readonly IMediator _mediator;

        public EmpresasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> CriarEmpresa([FromBody] CreateEmpresaCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
