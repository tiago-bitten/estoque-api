using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoEmpresaIdemCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logs_alteracoes_empresas_EmpresaId",
                table: "logs_alteracoes");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "logs_alteracoes",
                newName: "empresa_id");

            migrationBuilder.RenameIndex(
                name: "IX_logs_alteracoes_EmpresaId",
                table: "logs_alteracoes",
                newName: "IX_logs_alteracoes_empresa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_logs_alteracoes_empresas_empresa_id",
                table: "logs_alteracoes",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logs_alteracoes_empresas_empresa_id",
                table: "logs_alteracoes");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "logs_alteracoes",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_logs_alteracoes_empresa_id",
                table: "logs_alteracoes",
                newName: "IX_logs_alteracoes_EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_logs_alteracoes_empresas_EmpresaId",
                table: "logs_alteracoes",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
