using AutoMapper;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class EstoqueProdutoProfile : Profile
    {
        public EstoqueProdutoProfile()
        {
            CreateMap<EstoqueProduto, EstoqueProdutoDTO>();
        }
    }
}
