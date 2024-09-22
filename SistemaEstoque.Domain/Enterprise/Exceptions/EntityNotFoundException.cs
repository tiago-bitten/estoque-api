using SistemaEstoque.Domain.Entities.Abstracoes;

namespace SistemaEstoque.Domain.Enterprise.Exceptions;
public class EntityNotFoundException<T> : BaseException where T : IdentificadorBase
{
    public EntityNotFoundException(int id)
        : base($"Entity of type {typeof(T).Name} with id {id} not found.")
    {
    }

    public EntityNotFoundException(string message)
        : base(message)
    {
    }

    public EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EntityNotFoundException(Exception innerException)
        : base(innerException)
    {
    }

    public EntityNotFoundException(string message, Exception innerException, params object[] args)
        : base(message, innerException, args)
    {
    }

    public EntityNotFoundException(params object[] args)
        : base(args)
    {
    }
}
