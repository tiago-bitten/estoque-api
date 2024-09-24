namespace SistemaEstoque.Domain.Enterprise.Exceptions;

public abstract class BaseException : Exception
{
    public BaseException() : base("Critical error")
    {
    }

    protected BaseException(string message)
        : base(message)
    {
    }
    
    public BaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
    
    public BaseException(string message, Exception innerException, params object[] args)
        : base(string.Format(message, args), innerException)
    {
    }
    
    public BaseException(string message, params object[] args)
        : base(string.Format(message, args))
    {
    }
    
    public BaseException(Exception innerException)
        : base(innerException.Message, innerException)
    {
    }
    
    public BaseException(params object[] args)
        : base(string.Format(string.Empty, args))
    {
    }
}