using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVendaReferencia { get; set; }
        public decimal PrecoCustoReferencia { get; set; }
        public CategoriaDto Categoria { get; set; }
    }
}
