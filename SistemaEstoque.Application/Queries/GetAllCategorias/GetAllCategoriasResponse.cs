using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Application.Queries.GetAllCategorias
{
    public class GetAllCategoriasResponse : List<CategoriaDTO>, IPagedResponse
    {
        public int Total { get ; set ; }
     
        public GetAllCategoriasResponse(IEnumerable<CategoriaDTO> items, int total) 
        {
            this.AddRange(items);
            Total = total;
        }
    }
}
