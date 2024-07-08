using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaEstoque.Application.Profiles;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data;
using SistemaEstoque.Infra.Repositories;
using MediatR;
using System.Reflection;
using SistemaEstoque.Application.Commands.CreateUsuario;
using SistemaEstoque.Application.Commands.CreateCategoria;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Application.Services;
using SistemaEstoque.Application.Commands.CreateProduto;
using SistemaEstoque.Application.Commands.CreateFornecedor;
using SistemaEstoque.Application.Commands.CreateEstoque;
using SistemaEstoque.Application.Commands.CreateLote;

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
                    typeof(CreateUsuarioCommand).Assembly,
                    typeof(CreateCategoriaCommand).Assembly,
                    typeof(CreateProdutoCommand).Assembly,
                    typeof(CreateFornecedorCommand).Assembly,
                    typeof(CreateEstoqueCommand).Assembly,
                    typeof(CreateLoteCommand).Assembly,
                });
            });

            services.AddAutoMapper(typeof(CategoriaProfile));
            services.AddAutoMapper(typeof(ProdutoProfile));
            services.AddAutoMapper(typeof(UsuarioProfile));
            services.AddAutoMapper(typeof(FornecedorProfile));
            services.AddAutoMapper(typeof(EstoqueProfile));
            services.AddAutoMapper(typeof(LoteProfile));

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

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<ILoteRepository, LoteRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            //services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
