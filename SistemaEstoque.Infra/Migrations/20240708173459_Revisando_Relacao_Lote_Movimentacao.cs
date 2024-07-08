using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RevisandoRelacaoLoteMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_movimentacoes_lote_id",
                table: "movimentacoes");

            migrationBuilder.RenameColumn(
                name: "Removido",
                table: "movimentacoes",
                newName: "removido");

            migrationBuilder.RenameColumn(
                name: "origem_movimentacao",
                table: "movimentacoes",
                newName: "origem");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "movimentacoes",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_lote_id",
                table: "movimentacoes",
                column: "lote_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_movimentacoes_lote_id",
                table: "movimentacoes");

            migrationBuilder.RenameColumn(
                name: "removido",
                table: "movimentacoes",
                newName: "Removido");

            migrationBuilder.RenameColumn(
                name: "origem",
                table: "movimentacoes",
                newName: "origem_movimentacao");

            migrationBuilder.AlterColumn<bool>(
                name: "Removido",
                table: "movimentacoes",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_lote_id",
                table: "movimentacoes",
                column: "lote_id");
        }
    }
}
