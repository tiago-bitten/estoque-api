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

            CreateMap<CreatePerfilAcessoComannd, PermissaoProduto>()
                .BeforeMap((src, dest) =>
                {
                    dest.Visualizar = src.PermissaoProduto.Visualizar;
                    dest.Criar = src.PermissaoProduto.Criar;
                    dest.Editar = src.PermissaoProduto.Editar;
                    dest.Excluir = src.PermissaoProduto.Excluir;
                });
        }
    }
}
