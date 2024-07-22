using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajustandocolunaperfilacessoidempermissaocategoriaentidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerfilAcessoId",
                table: "permissoes_categorias",
                newName: "perfil_acesso_id");

            migrationBuilder.AlterColumn<int>(
                name: "perfil_acesso_id",
                table: "permissoes_categorias",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "perfil_acesso_id",
                table: "permissoes_categorias",
                newName: "PerfilAcessoId");

            migrationBuilder.AlterColumn<int>(
                name: "PerfilAcessoId",
                table: "permissoes_categorias",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
