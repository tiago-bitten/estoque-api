using AutoMapper;
using SistemaEstoque.Application.Commands.CreateCategoria;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaCommand, Categoria>();
            
            CreateMap<Categoria, CreateCategoriaResponse>();
        }
    }
}
