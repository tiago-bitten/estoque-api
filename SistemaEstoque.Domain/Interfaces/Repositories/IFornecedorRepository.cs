﻿using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
    {
        Task<Fornecedor?> GeyByCpfCnpj(string cpfCnpj);
    }
}