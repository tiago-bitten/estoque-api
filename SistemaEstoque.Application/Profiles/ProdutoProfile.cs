using AutoMapper;
using SistemaEstoque.Application.Commands.CreateProduto;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Queries.GetAllProdutos;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoCommand, Produto>();

            CreateMap<Produto, CreateProdutoResponse>();

            CreateMap<Produto, ProdutoDTO>();

            // CreateMap<Produto, UpdateProdutoResponse>();

            CreateMap<Produto, GetAllProdutosResponse>();
        }
    }
}
