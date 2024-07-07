using AutoMapper;
using SistemaEstoque.Application.Commands.CreateUsuario;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Application.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioCommand, Usuario>();

            CreateMap<Usuario, CreateUsuarioResponse>();
        }
    }
}
