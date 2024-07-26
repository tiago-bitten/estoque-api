using AutoMapper;
using SistemaEstoque.Application.Commands.CreatePerfilAcesso;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Entities.Permissoes;

namespace SistemaEstoque.Application.Profiles
{
    public class PerfilAcessoProfile : Profile   
    {
        public PerfilAcessoProfile()
        {
            CreateMap<CreatePerfilAcessoComannd, PerfilAcesso>()
                .ForMember(dest => dest.PermissaoProduto, opt => opt.Ignore());

            CreateMap<PerfilAcesso, CreatePerfilAcessoResponse>();

            CreateMap<CreatePerfilAcessoComannd, PermissaoProduto>()
                .BeforeMap((src, dest) =>
                {
                    dest.Visualizar = src.PermissaoProduto.Visualizar;
                    dest.Criar = src.PermissaoProduto.Criar;
                    dest.Editar = src.PermissaoProduto.Editar;
                    dest.Excluir = src.PermissaoProduto.Excluir;
                });

            CreateMap<CreatePerfilAcessoComannd, PermissaoCategoria>()
                .BeforeMap((src, dest) =>
                {
                    dest.Visualizar = src.PermissaoCategoria.Visualizar;
                    dest.Criar = src.PermissaoCategoria.Criar;
                    dest.Editar = src.PermissaoCategoria.Editar;
                    dest.Excluir = src.PermissaoCategoria.Excluir;
                });

            CreateMap<CreatePerfilAcessoComannd, PermissaoInsumo>()
                .BeforeMap((src, dest) =>
                {
                    dest.Visualizar = src.PermissaoInsumo.Visualizar;
                    dest.Criar = src.PermissaoInsumo.Criar;
                    dest.Editar = src.PermissaoInsumo.Editar;
                    dest.Excluir = src.PermissaoInsumo.Excluir;
                });
        }
    }
}
