namespace SistemaEstoque.Domain.Entities
{
    public sealed class Proprietario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool? Removido { get; set; }
    
        public ICollection<Empresa> Empresas { get; set; }
    }
}
