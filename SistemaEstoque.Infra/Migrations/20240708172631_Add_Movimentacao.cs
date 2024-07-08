using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movimentacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    datamovimentacao = table.Column<DateTime>(name: "data_movimentacao", type: "date", nullable: false),
                    precounitariovenda = table.Column<decimal>(name: "preco_unitario_venda", type: "numeric(10,2)", nullable: false),
                    precounitariocusto = table.Column<decimal>(name: "preco_unitario_custo", type: "numeric(10,2)", nullable: false),
                    origemmovimentacao = table.Column<string>(name: "origem_movimentacao", type: "text", nullable: false),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "int", nullable: false),
                    produtoid = table.Column<int>(name: "produto_id", type: "int", nullable: false),
                    loteid = table.Column<int>(name: "lote_id", type: "int", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimentacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_movimentacoes_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_movimentacoes_lotes_lote_id",
                        column: x => x.loteid,
                        principalTable: "lotes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_movimentacoes_produtos_produto_id",
                        column: x => x.produtoid,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_movimentacoes_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_empresa_id",
                table: "movimentacoes",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_lote_id",
                table: "movimentacoes",
                column: "lote_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produto_id",
                table: "movimentacoes",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_usuario_id",
                table: "movimentacoes",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentacoes");
        }
    }
}
