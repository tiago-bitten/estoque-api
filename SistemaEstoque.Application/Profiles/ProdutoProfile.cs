using AutoMapper;
using SistemaEstoque.Application.Commands.CreateItem;
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
            CreateMap<CreateItemCommand, Produto>();

            CreateMap<Produto, CreateItemResponse>();

            CreateMap<Produto, ProdutoDTO>();

            // CreateMap<Produto, UpdateProdutoResponse>();

            CreateMap<Produto, GetAllProdutosResponse>();
        }
    }
}
