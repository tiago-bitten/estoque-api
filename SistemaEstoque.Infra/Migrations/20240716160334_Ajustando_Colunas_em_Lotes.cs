using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoColunasemLotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estoques_empresas_empresa_id",
                table: "estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_estoques_produtos_produto_id",
                table: "estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_historicos_estoques_produtos_estoques_estoque_produto_id",
                table: "historicos_estoques_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_insumos_lotes_insumos_lote_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_produtos_estoques_estoque_produto_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_produtos_lotes_produtos_lote_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estoques",
                table: "estoques");

            migrationBuilder.RenameTable(
                name: "estoques",
                newName: "estoques_produtos");

            migrationBuilder.RenameColumn(
                name: "lote_id",
                table: "movimentacoes_produtos",
                newName: "lote_produto_id");

            migrationBuilder.RenameIndex(
                name: "IX_movimentacoes_produtos_lote_id",
                table: "movimentacoes_produtos",
                newName: "IX_movimentacoes_produtos_lote_produto_id");

            migrationBuilder.RenameColumn(
                name: "lote_id",
                table: "movimentacoes_insumos",
                newName: "lote_insumo_id");

            migrationBuilder.RenameIndex(
                name: "IX_movimentacoes_insumos_lote_id",
                table: "movimentacoes_insumos",
                newName: "IX_movimentacoes_insumos_lote_insumo_id");

            migrationBuilder.RenameIndex(
                name: "IX_estoques_produto_id",
                table: "estoques_produtos",
                newName: "IX_estoques_produtos_produto_id");

            migrationBuilder.RenameIndex(
                name: "IX_estoques_empresa_id",
                table: "estoques_produtos",
                newName: "IX_estoques_produtos_empresa_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estoques_produtos",
                table: "estoques_produtos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_estoques_produtos_empresas_empresa_id",
                table: "estoques_produtos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_estoques_produtos_produtos_produto_id",
                table: "estoques_produtos",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_historicos_estoques_produtos_estoques_produtos_estoque_prod~",
                table: "historicos_estoques_produtos",
                column: "estoque_produto_id",
                principalTable: "estoques_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_insumos_lotes_insumos_lote_insumo_id",
                table: "movimentacoes_insumos",
                column: "lote_insumo_id",
                principalTable: "lotes_insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_produtos_estoques_produtos_estoque_produto_id",
                table: "movimentacoes_produtos",
                column: "estoque_produto_id",
                principalTable: "estoques_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_produtos_lotes_produtos_lote_produto_id",
                table: "movimentacoes_produtos",
                column: "lote_produto_id",
                principalTable: "lotes_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estoques_produtos_empresas_empresa_id",
                table: "estoques_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_estoques_produtos_produtos_produto_id",
                table: "estoques_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_historicos_estoques_produtos_estoques_produtos_estoque_prod~",
                table: "historicos_estoques_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_insumos_lotes_insumos_lote_insumo_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_produtos_estoques_produtos_estoque_produto_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_produtos_lotes_produtos_lote_produto_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estoques_produtos",
                table: "estoques_produtos");

            migrationBuilder.RenameTable(
                name: "estoques_produtos",
                newName: "estoques");

            migrationBuilder.RenameColumn(
                name: "lote_produto_id",
                table: "movimentacoes_produtos",
                newName: "lote_id");

            migrationBuilder.RenameIndex(
                name: "IX_movimentacoes_produtos_lote_produto_id",
                table: "movimentacoes_produtos",
                newName: "IX_movimentacoes_produtos_lote_id");

            migrationBuilder.RenameColumn(
                name: "lote_insumo_id",
                table: "movimentacoes_insumos",
                newName: "lote_id");

            migrationBuilder.RenameIndex(
                name: "IX_movimentacoes_insumos_lote_insumo_id",
                table: "movimentacoes_insumos",
                newName: "IX_movimentacoes_insumos_lote_id");

            migrationBuilder.RenameIndex(
                name: "IX_estoques_produtos_produto_id",
                table: "estoques",
                newName: "IX_estoques_produto_id");

            migrationBuilder.RenameIndex(
                name: "IX_estoques_produtos_empresa_id",
                table: "estoques",
                newName: "IX_estoques_empresa_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estoques",
                table: "estoques",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_estoques_empresas_empresa_id",
                table: "estoques",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_estoques_produtos_produto_id",
                table: "estoques",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_historicos_estoques_produtos_estoques_estoque_produto_id",
                table: "historicos_estoques_produtos",
                column: "estoque_produto_id",
                principalTable: "estoques",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_insumos_lotes_insumos_lote_id",
                table: "movimentacoes_insumos",
                column: "lote_id",
                principalTable: "lotes_insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_produtos_estoques_estoque_produto_id",
                table: "movimentacoes_produtos",
                column: "estoque_produto_id",
                principalTable: "estoques",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_produtos_lotes_produtos_lote_id",
                table: "movimentacoes_produtos",
                column: "lote_id",
                principalTable: "lotes_produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
