using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.DTOs
{
    public class LoteInsumoDTO
    {
        public int Id { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioCompra { get; set; }
        public decimal PrecoUnitarioVenda { get; set; }
        public InsumoDTO Insumo { get; set; }
    }
}
