using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FixHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoUsuarioAcesso_empresas_EmpresaId",
                table: "HistoricoUsuarioAcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoUsuarioAcesso_usuarios_UsuarioId",
                table: "HistoricoUsuarioAcesso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoricoUsuarioAcesso",
                table: "HistoricoUsuarioAcesso");

            migrationBuilder.RenameTable(
                name: "HistoricoUsuarioAcesso",
                newName: "historicos_usuarios_acessos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "historicos_usuarios_acessos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "historicos_usuarios_acessos",
                newName: "usuario_id");

            migrationBuilder.RenameColumn(
                name: "UserAgent",
                table: "historicos_usuarios_acessos",
                newName: "user_agent");

            migrationBuilder.RenameColumn(
                name: "IpAcesso",
                table: "historicos_usuarios_acessos",
                newName: "ip_acesso");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "historicos_usuarios_acessos",
                newName: "empresa_id");

            migrationBuilder.RenameColumn(
                name: "DataAcesso",
                table: "historicos_usuarios_acessos",
                newName: "data_acesso");

            migrationBuilder.RenameColumn(
                name: "AcessoValido",
                table: "historicos_usuarios_acessos",
                newName: "acesso_valido");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricoUsuarioAcesso_UsuarioId",
                table: "historicos_usuarios_acessos",
                newName: "IX_historicos_usuarios_acessos_usuario_id");

            migrationBuilder.RenameIndex(
                name: "IX_HistoricoUsuarioAcesso_EmpresaId",
                table: "historicos_usuarios_acessos",
                newName: "IX_historicos_usuarios_acessos_empresa_id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "historicos_usuarios_acessos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "user_agent",
                table: "historicos_usuarios_acessos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ip_acesso",
                table: "historicos_usuarios_acessos",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_acesso",
                table: "historicos_usuarios_acessos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_historicos_usuarios_acessos",
                table: "historicos_usuarios_acessos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_historicos_usuarios_acessos_empresas_empresa_id",
                table: "historicos_usuarios_acessos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_historicos_usuarios_acessos_usuarios_usuario_id",
                table: "historicos_usuarios_acessos",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historicos_usuarios_acessos_empresas_empresa_id",
                table: "historicos_usuarios_acessos");

            migrationBuilder.DropForeignKey(
                name: "FK_historicos_usuarios_acessos_usuarios_usuario_id",
                table: "historicos_usuarios_acessos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_historicos_usuarios_acessos",
                table: "historicos_usuarios_acessos");

            migrationBuilder.RenameTable(
                name: "historicos_usuarios_acessos",
                newName: "HistoricoUsuarioAcesso");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "HistoricoUsuarioAcesso",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "HistoricoUsuarioAcesso",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "user_agent",
                table: "HistoricoUsuarioAcesso",
                newName: "UserAgent");

            migrationBuilder.RenameColumn(
                name: "ip_acesso",
                table: "HistoricoUsuarioAcesso",
                newName: "IpAcesso");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "HistoricoUsuarioAcesso",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "data_acesso",
                table: "HistoricoUsuarioAcesso",
                newName: "DataAcesso");

            migrationBuilder.RenameColumn(
                name: "acesso_valido",
                table: "HistoricoUsuarioAcesso",
                newName: "AcessoValido");

            migrationBuilder.RenameIndex(
                name: "IX_historicos_usuarios_acessos_usuario_id",
                table: "HistoricoUsuarioAcesso",
                newName: "IX_HistoricoUsuarioAcesso_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_historicos_usuarios_acessos_empresa_id",
                table: "HistoricoUsuarioAcesso",
                newName: "IX_HistoricoUsuarioAcesso_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HistoricoUsuarioAcesso",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UserAgent",
                table: "HistoricoUsuarioAcesso",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "IpAcesso",
                table: "HistoricoUsuarioAcesso",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAcesso",
                table: "HistoricoUsuarioAcesso",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoricoUsuarioAcesso",
                table: "HistoricoUsuarioAcesso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoUsuarioAcesso_empresas_EmpresaId",
                table: "HistoricoUsuarioAcesso",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoUsuarioAcesso_usuarios_UsuarioId",
                table: "HistoricoUsuarioAcesso",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
