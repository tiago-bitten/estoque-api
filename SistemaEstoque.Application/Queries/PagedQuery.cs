namespace SistemaEstoque.Application.Queries;

public abstract class PagedQuery
{
    protected PagedQuery(int page, int size)
    {
        if (page < 1) throw new ArgumentException("Page must be greater than 0.");
        if (size < 1) throw new ArgumentException("Size must be greater than 0.");
            
        Page = page;
        Size = size;
    }
        
    public int Page { get; }
    public int Size { get; }
}