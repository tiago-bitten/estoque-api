using AutoMapper;
using SistemaEstoque.Application.Commands.CreateFornecedor;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<CreateFornecedorCommand, Fornecedor>();

            CreateMap<Fornecedor, CreateFornecedorResponse>();

            CreateMap<Fornecedor, FornecedorDTO>();
        }
    }
}
