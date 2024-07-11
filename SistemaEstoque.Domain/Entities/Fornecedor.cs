﻿namespace SistemaEstoque.Domain.Entities
{
    public class Fornecedor : EntidadeBase
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public bool? Removido { get; set; }

        public IEnumerable<LoteProduto?> LotesProdutos { get; set; }
        public IEnumerable<LoteInsumo?> LotesInsumos { get; set; }
    }
}