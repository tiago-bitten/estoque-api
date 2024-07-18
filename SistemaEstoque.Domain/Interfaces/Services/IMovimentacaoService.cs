using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IMovimentacaoService<T> : IServiceBase<T> where T : Movimentacao
    {
    }
}
