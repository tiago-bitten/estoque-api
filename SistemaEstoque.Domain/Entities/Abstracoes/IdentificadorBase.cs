namespace SistemaEstoque.Domain.Entities.Abstracoes
{
    public abstract class IdentificadorBase
    {
        public int Id { get; set; }
        public bool Removido { get; set; } = false;
    }
}
