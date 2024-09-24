using SistemaEstoque.Shared.Util;

namespace SistemaEstoque.Application.Queries
{
    public abstract class PagedResponse<T> where T : class
    {
        public PagedResult<T> PagedResult { get; set; }

        protected PagedResponse(PagedResult<T> result)
        {
            PagedResult = result;
        }
    }
}