using AutoMapper;
using SistemaEstoque.Application.Commands.CreateProduto;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoCommand, Produto>();

            CreateMap<Produto, CreateProdutoResponse>();
        }
    }
}
