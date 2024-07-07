using AutoMapper;
using SistemaEstoque.Application.Commands.CreateEstoque;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class EstoqueProfile : Profile
    {
        public EstoqueProfile()
        {
            CreateMap<CreateEstoqueCommand, Estoque>();

            CreateMap<Estoque, CreateEstoqueResponse>();
        }
    }
}
