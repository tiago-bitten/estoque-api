using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoLoteeMovimentacaoparaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentacoes");

            migrationBuilder.DropTable(
                name: "lotes");

            migrationBuilder.CreateTable(
                name: "lotes_produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "varchar(50)", nullable: false),
                    codigobarras = table.Column<string>(name: "codigo_barras", type: "varchar(255)", nullable: false),
                    datafabricacao = table.Column<DateTime>(name: "data_fabricacao", type: "timestamp", nullable: false),
                    datavalidade = table.Column<DateTime>(name: "data_validade", type: "timestamp", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    produtoid = table.Column<int>(name: "produto_id", type: "int", nullable: false),
                    fornecedorid = table.Column<int>(name: "fornecedor_id", type: "int", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lotes_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_lotes_produtos_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_lotes_produtos_fornecedores_fornecedor_id",
                        column: x => x.fornecedorid,
                        principalTable: "fornecedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_lotes_produtos_produtos_produto_id",
                        column: x => x.produtoid,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "movimentacoes_produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    datamovimentacao = table.Column<DateTime>(name: "data_movimentacao", type: "date", nullable: false),
                    precounitariovenda = table.Column<decimal>(name: "preco_unitario_venda", type: "numeric(10,2)", nullable: false),
                    precounitariocusto = table.Column<decimal>(name: "preco_unitario_custo", type: "numeric(10,2)", nullable: false),
                    origem = table.Column<string>(type: "text", nullable: false),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "int", nullable: false),
                    produtoid = table.Column<int>(name: "produto_id", type: "int", nullable: false),
                    loteid = table.Column<int>(name: "lote_id", type: "int", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimentacoes_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_movimentacoes_produtos_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_movimentacoes_produtos_lotes_produtos_lote_id",
                        column: x => x.loteid,
                        principalTable: "lotes_produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_movimentacoes_produtos_produtos_produto_id",
                        column: x => x.produtoid,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_movimentacoes_produtos_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lotes_produtos_empresa_id",
                table: "lotes_produtos",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_lotes_produtos_fornecedor_id",
                table: "lotes_produtos",
                column: "fornecedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_lotes_produtos_produto_id",
                table: "lotes_produtos",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produtos_empresa_id",
                table: "movimentacoes_produtos",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produtos_lote_id",
                table: "movimentacoes_produtos",
                column: "lote_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produtos_produto_id",
                table: "movimentacoes_produtos",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produtos_usuario_id",
                table: "movimentacoes_produtos",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentacoes_produtos");

            migrationBuilder.DropTable(
                name: "lotes_produtos");

            migrationBuilder.CreateTable(
                name: "lotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    fornecedorid = table.Column<int>(name: "fornecedor_id", type: "int", nullable: false),
                    produtoid = table.Column<int>(name: "produto_id", type: "int", nullable: false),
                    codigo = table.Column<string>(type: "varchar(50)", nullable: false),
                    codigobarras = table.Column<string>(name: "codigo_barras", type: "varchar(255)", nullable: false),
                    datafabricacao = table.Column<DateTime>(name: "data_fabricacao", type: "date", nullable: false),
                    datavalidade = table.Column<DateTime>(name: "data_validade", type: "date", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_lotes_fornecedores_fornecedor_id",
                        column: x => x.fornecedorid,
                        principalTable: "fornecedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_lotes_produtos_produto_id",
                        column: x => x.produtoid,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "movimentacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    loteid = table.Column<int>(name: "lote_id", type: "int", nullable: false),
                    produtoid = table.Column<int>(name: "produto_id", type: "int", nullable: false),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "int", nullable: false),
                    datamovimentacao = table.Column<DateTime>(name: "data_movimentacao", type: "date", nullable: false),
                    origem = table.Column<string>(type: "text", nullable: false),
                    precounitariocusto = table.Column<decimal>(name: "preco_unitario_custo", type: "numeric(10,2)", nullable: false),
                    precounitariovenda = table.Column<decimal>(name: "preco_unitario_venda", type: "numeric(10,2)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    tipo = table.Column<string>(type: "text", nullable: false)
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
                name: "IX_lotes_empresa_id",
                table: "lotes",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_lotes_fornecedor_id",
                table: "lotes",
                column: "fornecedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_lotes_produto_id",
                table: "lotes",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_empresa_id",
                table: "movimentacoes",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_lote_id",
                table: "movimentacoes",
                column: "lote_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_produto_id",
                table: "movimentacoes",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_usuario_id",
                table: "movimentacoes",
                column: "usuario_id");
        }
    }
}
