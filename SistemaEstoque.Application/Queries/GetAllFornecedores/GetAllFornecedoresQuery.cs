using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.Queries.GetAllFornecedores
{
    public class GetAllFornecedoresQuery : PagedQuery, IRequest<GetAllFornecedoresResponse>
    {
        public GetAllFornecedoresQuery(int page, int size) : base(page, size)
        {
            
        }
    }
}
