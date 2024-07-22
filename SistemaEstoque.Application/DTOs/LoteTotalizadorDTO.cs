namespace SistemaEstoque.Application.DTOs
{
    public class LoteTotalizadorDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataRecebimento { get; set; }
        public int Total { get; set; }
        public int Saidas { get; set; }
        public int Entradas { get; set; }

    }
}
