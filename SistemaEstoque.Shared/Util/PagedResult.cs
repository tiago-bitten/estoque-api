namespace SistemaEstoque.Infra.Util;

public class PagedResult<T> where T : class
{
    public IEnumerable<T> Data { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public int Total { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
}
