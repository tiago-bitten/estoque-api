﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaEstoque.Infra.Data;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    [DbContext(typeof(SistemaEstoqueDbContext))]
    [Migration("20240707050936_Add_Usuario_Categoria_Produto_Categoria")]
    partial class AddUsuarioCategoriaProdutoCategoria
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("descricao");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<bool?>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BOOLEAN")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("cidade");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("endereco");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("estado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefone");

                    b.Property<string>("TipoEmpresa")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tipo_empresa");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("descricao");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<decimal?>("PrecoCusto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("preco_custo");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("preco_venda");

                    b.Property<bool?>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("AcessoBloqueado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("acesso_bloqueado");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<bool?>("Removido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("removido");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Categoria", b =>
                {
                    b.HasOne("SistemaEstoque.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Categorias")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Produto", b =>
                {
                    b.HasOne("SistemaEstoque.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaEstoque.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Produtos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("SistemaEstoque.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Usuarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("SistemaEstoque.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Produtos");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
