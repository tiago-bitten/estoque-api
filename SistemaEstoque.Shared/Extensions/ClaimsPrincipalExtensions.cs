using System.Security.Claims;

namespace SistemaEstoque.Shared.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetUsuarioId(this ClaimsPrincipal claimsPrincipal)
    {
        var usuarioIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(usuarioIdClaim) || !int.TryParse(usuarioIdClaim, out var usuarioId))
            throw new UnauthorizedAccessException("Não foi possível identificar o usuário no token.");

        return usuarioId;
    }
}
