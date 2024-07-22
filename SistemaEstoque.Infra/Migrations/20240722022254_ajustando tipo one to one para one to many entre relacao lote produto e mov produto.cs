using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajustandotipoonetooneparaonetomanyentrerelacaoloteprodutoemovproduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_movimentacoes_produtos_lote_produto_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropIndex(
                name: "IX_movimentacoes_insumos_lote_insumo_id",
                table: "movimentacoes_insumos");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produtos_lote_produto_id",
                table: "movimentacoes_produtos",
                column: "lote_produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_insumos_lote_insumo_id",
                table: "movimentacoes_insumos",
                column: "lote_insumo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_movimentacoes_produtos_lote_produto_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropIndex(
                name: "IX_movimentacoes_insumos_lote_insumo_id",
                table: "movimentacoes_insumos");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produtos_lote_produto_id",
                table: "movimentacoes_produtos",
                column: "lote_produto_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_insumos_lote_insumo_id",
                table: "movimentacoes_insumos",
                column: "lote_insumo_id",
                unique: true);
        }
    }
}
