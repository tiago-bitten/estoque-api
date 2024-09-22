using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaEstoque.Application.Profiles;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using SistemaEstoque.Infra.Repositories;
using System.Reflection;
using SistemaEstoque.Application.Commands.CreateUsuario;
using SistemaEstoque.Application.Commands.CreateCategoria;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Application.Services;
using SistemaEstoque.Application.Commands.CreateProduto;
using SistemaEstoque.Application.Commands.CreateFornecedor;
using SistemaEstoque.Application.Commands.CreateEstoque;
using SistemaEstoque.Application.Commands.CreateLote;
using SistemaEstoque.Application.Commands.UpdateCategoria;
using SistemaEstoque.Application.Commands.CreateInsumo;
using SistemaEstoque.Application.Queries.GetAllCategorias;
using SistemaEstoque.Application.Queries.GetAllProdutos;
using SistemaEstoque.Application.Queries.GetAllInsumos;
using SistemaEstoque.Application.Queries.GetAllEstoquesProdutos;
using SistemaEstoque.Application.Queries.GetAllFornecedores;
using SistemaEstoque.Application.Commands.CreateEstoqueInsumo;
using SistemaEstoque.Application.Queries.GetAllEstoquesInsumos;
using SistemaEstoque.Application.Queries.GetAllLotes;
using SistemaEstoque.Application.Commands.CreatePerfilAcesso;
using SistemaEstoque.Application.Commands.CreateEmpresa;
using SistemaEstoque.Application.Commands.Login;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SistemaEstoqueDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(new Assembly[] 
                { 
                    typeof(LoginCommand).Assembly,
                    
                    typeof(CreateUsuarioCommand).Assembly,
                    typeof(CreateCategoriaCommand).Assembly,
                    typeof(CreateProdutoCommand).Assembly,
                    typeof(CreateInsumoCommand).Assembly,
                    typeof(CreateFornecedorCommand).Assembly,
                    typeof(CreateEstoqueProdutoCommand).Assembly,
                    typeof(CreateEstoqueInsumoCommand).Assembly,
                    typeof(CreateLoteCommand).Assembly,
                    typeof(CreatePerfilAcessoComannd).Assembly,
                    typeof(CreateEmpresaCommand).Assembly,

                    typeof(UpdateCategoriaCommand).Assembly,
                    
                    typeof(GetAllCategoriasQuery).Assembly,
                    typeof(GetAllProdutosQuery).Assembly,
                    typeof(GetAllInsumosQuery).Assembly,
                    typeof(GetAllEstoquesProdutosQuery).Assembly,
                    typeof(GetAllEstoquesInsumosQuery).Assembly,
                    typeof(GetAllFornecedoresQuery).Assembly,
                    typeof(GetAllLotesQuery).Assembly
                });
            });

            services.AddAutoMapper(typeof(CategoriaProfile));
            services.AddAutoMapper(typeof(ProdutoProfile));
            services.AddAutoMapper(typeof(UsuarioProfile));
            services.AddAutoMapper(typeof(FornecedorProfile));
            services.AddAutoMapper(typeof(EstoqueProdutoProfile));
            services.AddAutoMapper(typeof(EstoqueInsumoProfile));
            services.AddAutoMapper(typeof(LoteProdutoProfile));
            services.AddAutoMapper(typeof(InsumoProfile));
            services.AddAutoMapper(typeof(LoteInsumoProfile));
            services.AddAutoMapper(typeof(MovimentacaoProdutoProfile));
            services.AddAutoMapper(typeof(MovimentacaoInsumoProfile));
            services.AddAutoMapper(typeof(LoteProfile));
            services.AddAutoMapper(typeof(PerfilAcessoProfile));
            services.AddAutoMapper(typeof(EmpresaProfile));
            services.AddAutoMapper(typeof(ProprietarioProfile));

            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<ILoteRepository, LoteRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddScoped<IRegistroAlteracaoEntidadeRepository, RegistroAlteracaoEntidadeEntidadeRepository>();
            services.AddScoped<IRemesaLoteRepository, RemesaLoteRepository>();
            services.AddScoped<IPerfilAcessoRepository, PerfilAcessoRepository>();
            services.AddScoped<IPermissaoProdutoRepository, PermissaoProdutoRepository>();
            services.AddScoped<IPermissaoCategoriaRepository, PermissaoCategoriaRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<IConfiguracaoEstoqueRepository, ConfiguracaoEstoqueRepository>();
            services.AddScoped<IPermissaoInsumoRepository, PermissaoInsumoRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<ILoteService, LoteService>();
            services.AddScoped<IProprietarioService, ProprietarioService>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IAmbienteUsuario, AmbienteUsuario>();
            //services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
