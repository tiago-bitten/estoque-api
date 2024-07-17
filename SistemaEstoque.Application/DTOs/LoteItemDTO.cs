using SistemaEstoque.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.DTOs
{
    public class LoteItemDTO
    {
        public ETipoItem TipoItem { get; set; }
        public int ItemId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public decimal PrecoUnitarioCusto { get; set; }
        public decimal PrecoUnitarioVenda { get; set; }
    }
}
