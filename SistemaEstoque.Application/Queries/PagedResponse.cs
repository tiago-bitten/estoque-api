using SistemaEstoque.Shared.Util;

namespace SistemaEstoque.Application.Queries
{
    public abstract class PagedResponse<T> where T : class
    {
        public PagedResult<T> Result { get; set; }

        protected PagedResponse(PagedResult<T> result)
        {
            Result = result;
        }
    }
}