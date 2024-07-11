namespace SistemaEstoque.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool? AcessoBloqueado { get; set; }

        public IEnumerable<MovimentacaoProduto?> MovimentacoesProdutos { get; set; }
        public IEnumerable<MovimentoInsumo?> MovimentacoesInsumos { get; set; }
        public IEnumerable<LogAlteracao?> LogsAlteracoes { get; set; }
    }
}