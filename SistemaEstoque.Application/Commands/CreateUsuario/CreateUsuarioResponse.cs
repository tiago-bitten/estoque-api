namespace SistemaEstoque.Application.Commands.CreateUsuario
{
    public class CreateUsuarioResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool? AcessoBloqueado { get; set; }
    }
}
