using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ColunaAjustada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorias_empresas_EmpresaId",
                table: "categorias");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "categorias",
                newName: "empresa_id");

            migrationBuilder.RenameIndex(
                name: "IX_categorias_EmpresaId",
                table: "categorias",
                newName: "IX_categorias_empresa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_categorias_empresas_empresa_id",
                table: "categorias",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorias_empresas_empresa_id",
                table: "categorias");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "categorias",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_categorias_empresa_id",
                table: "categorias",
                newName: "IX_categorias_EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_categorias_empresas_EmpresaId",
                table: "categorias",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
