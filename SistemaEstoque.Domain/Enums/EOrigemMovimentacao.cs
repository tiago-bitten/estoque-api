using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Enums
{
    public enum EOrigemMovimentacao
    {
        Compra = 1,
        Venda = 2,
        Devolucao = 3,
        Ajuste = 4,
        EntradaLote = 5,
        SaidaLote = 6,
        EntradaManual = 7,
        SaidaManual = 8
    }
}
