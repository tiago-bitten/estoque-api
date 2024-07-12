﻿using Microsoft.EntityFrameworkCore;
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
using SistemaEstoque.Application.Commands.UpdateCategoria;
using SistemaEstoque.Application.Commands.CreateInsumo;
using SistemaEstoque.Application.Commands.CreateLoteInsumo;

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
                    typeof(CreateInsumoCommand).Assembly,
                    typeof(CreateFornecedorCommand).Assembly,
                    typeof(CreateEstoqueProdutoCommand).Assembly,
                    typeof(CreateLoteProdutoCommand).Assembly,
                    typeof(CreateLoteInsumoCommand).Assembly,
                    typeof(UpdateCategoriaCommand).Assembly
                });
            });

            services.AddAutoMapper(typeof(CategoriaProfile));
            services.AddAutoMapper(typeof(ProdutoProfile));
            services.AddAutoMapper(typeof(UsuarioProfile));
            services.AddAutoMapper(typeof(FornecedorProfile));
            services.AddAutoMapper(typeof(EstoqueProfile));
            services.AddAutoMapper(typeof(LoteProdutoProfile));
            services.AddAutoMapper(typeof(InsumoProfile));
            services.AddAutoMapper(typeof(LoteInsumoProfile));
            services.AddAutoMapper(typeof(MovimentacaoProdutoProfile));
            services.AddAutoMapper(typeof(MovimentacaoInsumoProfile));

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
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEstoqueProdutoRepository, EstoqueProdutoRepository>();
            services.AddScoped<ILoteProdutoRepository, LoteProdutoRepository>();
            services.AddScoped<IMovimentacaoProdutoRepository, MovimentacaoProdutoRepository>();
            services.AddScoped<ILogAlteracaoRepository, LogAlteracaoRepository>();
            services.AddScoped<IInsumoRepository, InsumoRepository>();
            services.AddScoped<ILoteInsumoRepository, LoteInsumoRepository>();
            services.AddScoped<IMovimentacaoInsumoRepository, MovimentacaoInsumoRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILogAlteracaoService<>), typeof(LogAlteracaoService<>));
            services.AddScoped(typeof(IEstoqueService<>), typeof(EstoqueService<>));
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<ILoteProdutoService, LoteProdutoService>();
            services.AddScoped<IInsumoService, InsumoService>();
            //services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
