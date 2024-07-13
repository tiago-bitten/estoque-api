namespace SistemaEstoque.Application.Responses
{
    public interface IPagedQuery
    {
        int Skip { get; set; }
        int Take { get; set; }
    }
}
