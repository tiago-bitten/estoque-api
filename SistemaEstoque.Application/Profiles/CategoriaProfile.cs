using AutoMapper;
using SistemaEstoque.Application.Commands.CreateCategoria;
using SistemaEstoque.Application.Commands.UpdateCategoria;
using SistemaEstoque.Application.DTOs;
using SistemaEstoque.Application.Queries.GetAllCategorias;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaCommand, Categoria>();
            
            CreateMap<Categoria, CreateCategoriaResponse>();

            CreateMap<Categoria, CategoriaDTO>();

            CreateMap<Categoria, UpdateCategoriaResponse>();

            CreateMap<Categoria, GetAllCategoriasResponse>();
        }
    }
}
