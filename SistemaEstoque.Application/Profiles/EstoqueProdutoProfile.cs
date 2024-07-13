using AutoMapper;
using SistemaEstoque.Application.Commands.CreateEstoque;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class EstoqueProdutoProfile : Profile
    {
        public EstoqueProdutoProfile()
        {
            CreateMap<EstoqueProduto, EstoqueProdutoDTO>();

            CreateMap<CreateEstoqueProdutoCommand, EstoqueProduto>();

            CreateMap<EstoqueProduto, CreateEstoqueProdutoResponse>();
        }
    }
}
