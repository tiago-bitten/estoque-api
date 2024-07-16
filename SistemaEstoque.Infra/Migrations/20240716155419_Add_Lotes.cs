using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddLotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lotes_insumos_fornecedores_fornecedor_id",
                table: "lotes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_lotes_produtos_fornecedores_fornecedor_id",
                table: "lotes_produtos");

            migrationBuilder.DropColumn(
                name: "codigo",
                table: "lotes_produtos");

            migrationBuilder.DropColumn(
                name: "codigo_barras",
                table: "lotes_produtos");

            migrationBuilder.DropColumn(
                name: "codigo",
                table: "lotes_insumos");

            migrationBuilder.DropColumn(
                name: "codigo_barras",
                table: "lotes_insumos");

            migrationBuilder.RenameColumn(
                name: "fornecedor_id",
                table: "lotes_produtos",
                newName: "LoteId");

            migrationBuilder.RenameIndex(
                name: "IX_lotes_produtos_fornecedor_id",
                table: "lotes_produtos",
                newName: "IX_lotes_produtos_LoteId");

            migrationBuilder.RenameColumn(
                name: "fornecedor_id",
                table: "lotes_insumos",
                newName: "lote_id");

            migrationBuilder.RenameIndex(
                name: "IX_lotes_insumos_fornecedor_id",
                table: "lotes_insumos",
                newName: "IX_lotes_insumos_lote_id");

            migrationBuilder.AddColumn<int>(
                name: "estoque_produto_id",
                table: "movimentacoes_produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "estoque_insumo_id",
                table: "movimentacoes_insumos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitarioCompra",
                table: "lotes_produtos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitarioVenda",
                table: "lotes_produtos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "lotes_insumos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_fabricacao",
                table: "lotes_insumos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitarioCompra",
                table: "lotes_insumos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitarioVenda",
                table: "lotes_insumos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "lotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "varchar(150)", nullable: false),
                    codigo = table.Column<string>(type: "varchar(200)", nullable: false),
                    codigobarras = table.Column<string>(name: "codigo_barras", type: "varchar(200)", nullable: false),
                    fornecedorid = table.Column<int>(name: "fornecedor_id", type: "int", nullable: false),
                    datarecebimento = table.Column<DateTime>(name: "data_recebimento", type: "timestamp", nullable: false),
                    usuariorecebimentoid = table.Column<int>(name: "usuario_recebimento_id", type: "int", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_lotes_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lotes_fornecedores_fornecedor_id",
                        column: x => x.fornecedorid,
                        principalTable: "fornecedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lotes_usuarios_usuario_recebimento_id",
                        column: x => x.usuariorecebimentoid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produtos_estoque_produto_id",
                table: "movimentacoes_produtos",
                column: "estoque_produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_insumos_estoque_insumo_id",
                table: "movimentacoes_insumos",
                column: "estoque_insumo_id");

            migrationBuilder.CreateIndex(
                name: "IX_lotes_empresa_id",
                table: "lotes",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_lotes_fornecedor_id",
                table: "lotes",
                column: "fornecedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_lotes_usuario_recebimento_id",
                table: "lotes",
                column: "usuario_recebimento_id");

            migrationBuilder.AddForeignKey(
                name: "FK_lotes_insumos_lotes_lote_id",
                table: "lotes_insumos",
                column: "lote_id",
                principalTable: "lotes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lotes_produtos_lotes_LoteId",
                table: "lotes_produtos",
                column: "LoteId",
                principalTable: "lotes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_insumos_estoques_insumos_estoque_insumo_id",
                table: "movimentacoes_insumos",
                column: "estoque_insumo_id",
                principalTable: "estoques_insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_produtos_estoques_estoque_produto_id",
                table: "movimentacoes_produtos",
                column: "estoque_produto_id",
                principalTable: "estoques",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lotes_insumos_lotes_lote_id",
                table: "lotes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_lotes_produtos_lotes_LoteId",
                table: "lotes_produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_insumos_estoques_insumos_estoque_insumo_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_produtos_estoques_estoque_produto_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropTable(
                name: "lotes");

            migrationBuilder.DropIndex(
                name: "IX_movimentacoes_produtos_estoque_produto_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropIndex(
                name: "IX_movimentacoes_insumos_estoque_insumo_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropColumn(
                name: "estoque_produto_id",
                table: "movimentacoes_produtos");

            migrationBuilder.DropColumn(
                name: "estoque_insumo_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropColumn(
                name: "PrecoUnitarioCompra",
                table: "lotes_produtos");

            migrationBuilder.DropColumn(
                name: "PrecoUnitarioVenda",
                table: "lotes_produtos");

            migrationBuilder.DropColumn(
                name: "PrecoUnitarioCompra",
                table: "lotes_insumos");

            migrationBuilder.DropColumn(
                name: "PrecoUnitarioVenda",
                table: "lotes_insumos");

            migrationBuilder.RenameColumn(
                name: "LoteId",
                table: "lotes_produtos",
                newName: "fornecedor_id");

            migrationBuilder.RenameIndex(
                name: "IX_lotes_produtos_LoteId",
                table: "lotes_produtos",
                newName: "IX_lotes_produtos_fornecedor_id");

            migrationBuilder.RenameColumn(
                name: "lote_id",
                table: "lotes_insumos",
                newName: "fornecedor_id");

            migrationBuilder.RenameIndex(
                name: "IX_lotes_insumos_lote_id",
                table: "lotes_insumos",
                newName: "IX_lotes_insumos_fornecedor_id");

            migrationBuilder.AddColumn<string>(
                name: "codigo",
                table: "lotes_produtos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "codigo_barras",
                table: "lotes_produtos",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "lotes_insumos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_fabricacao",
                table: "lotes_insumos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AddColumn<string>(
                name: "codigo",
                table: "lotes_insumos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "codigo_barras",
                table: "lotes_insumos",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_lotes_insumos_fornecedores_fornecedor_id",
                table: "lotes_insumos",
                column: "fornecedor_id",
                principalTable: "fornecedores",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_lotes_produtos_fornecedores_fornecedor_id",
                table: "lotes_produtos",
                column: "fornecedor_id",
                principalTable: "fornecedores",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
