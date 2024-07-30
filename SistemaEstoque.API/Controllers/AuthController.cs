using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Application.Commands.Login;
using SistemaEstoque.Application.Commands.RefreshToken;
using SistemaEstoque.Application.Queries.GetAllTenantsLogin;

namespace SistemaEstoque.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var response = await _mediator.Send(command);

        HttpContext.Items["MensagemAPI"] = "Login realizado";

        return Ok(response);
    }
    
    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var response = await _mediator.Send(command);

        HttpContext.Items["MensagemAPI"] = "Token atualizado";

        return Ok(response);
    }

    [HttpGet("Tenants")]
    public async Task<IActionResult> GetTentants([FromQuery] GetAllTenantsLoginQuery query)
    {
        var response = await _mediator.Send(query);

        HttpContext.Items["MensagemAPI"] = "Tenants recuparados";

        return Ok(response);
    }
}