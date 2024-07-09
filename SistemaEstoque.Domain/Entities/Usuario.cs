namespace SistemaEstoque.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool? AcessoBloqueado { get; set; }

        public virtual ICollection<LogAlteracao?> LogsAlteracoes { get; set; }
    }
}