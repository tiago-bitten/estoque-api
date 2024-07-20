using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adddbsetconfigpermissoescategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_perfis_acessos_PermissaoCategoria_id",
                table: "perfis_acessos");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissaoCategoria_empresas_EmpresaId",
                table: "PermissaoCategoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissaoCategoria",
                table: "PermissaoCategoria");

            migrationBuilder.RenameTable(
                name: "PermissaoCategoria",
                newName: "permissoes_categorias");

            migrationBuilder.RenameColumn(
                name: "Visualizar",
                table: "permissoes_categorias",
                newName: "visualizar");

            migrationBuilder.RenameColumn(
                name: "Removido",
                table: "permissoes_categorias",
                newName: "removido");

            migrationBuilder.RenameColumn(
                name: "Excluir",
                table: "permissoes_categorias",
                newName: "excluir");

            migrationBuilder.RenameColumn(
                name: "Editar",
                table: "permissoes_categorias",
                newName: "editar");

            migrationBuilder.RenameColumn(
                name: "Criar",
                table: "permissoes_categorias",
                newName: "criar");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "permissoes_categorias",
                newName: "empresa_id");

            migrationBuilder.RenameIndex(
                name: "IX_PermissaoCategoria_EmpresaId",
                table: "permissoes_categorias",
                newName: "IX_permissoes_categorias_empresa_id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "perfis_acessos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "permissoes_categorias",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "permissoes_categorias",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissoes_categorias",
                table: "permissoes_categorias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_categorias_empresas_empresa_id",
                table: "permissoes_categorias",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_Id",
                table: "permissoes_categorias",
                column: "Id",
                principalTable: "perfis_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_categorias_empresas_empresa_id",
                table: "permissoes_categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_Id",
                table: "permissoes_categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissoes_categorias",
                table: "permissoes_categorias");

            migrationBuilder.RenameTable(
                name: "permissoes_categorias",
                newName: "PermissaoCategoria");

            migrationBuilder.RenameColumn(
                name: "visualizar",
                table: "PermissaoCategoria",
                newName: "Visualizar");

            migrationBuilder.RenameColumn(
                name: "removido",
                table: "PermissaoCategoria",
                newName: "Removido");

            migrationBuilder.RenameColumn(
                name: "excluir",
                table: "PermissaoCategoria",
                newName: "Excluir");

            migrationBuilder.RenameColumn(
                name: "editar",
                table: "PermissaoCategoria",
                newName: "Editar");

            migrationBuilder.RenameColumn(
                name: "criar",
                table: "PermissaoCategoria",
                newName: "Criar");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "PermissaoCategoria",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_permissoes_categorias_empresa_id",
                table: "PermissaoCategoria",
                newName: "IX_PermissaoCategoria_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "perfis_acessos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Removido",
                table: "PermissaoCategoria",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PermissaoCategoria",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissaoCategoria",
                table: "PermissaoCategoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_perfis_acessos_PermissaoCategoria_id",
                table: "perfis_acessos",
                column: "id",
                principalTable: "PermissaoCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissaoCategoria_empresas_EmpresaId",
                table: "PermissaoCategoria",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
