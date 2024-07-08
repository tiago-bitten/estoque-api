using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddLote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "varchar(50)", nullable: false),
                    codigobarras = table.Column<string>(name: "codigo_barras", type: "varchar(255)", nullable: false),
                    datafabricacao = table.Column<DateTime>(name: "data_fabricacao", type: "date", nullable: false),
                    datavalidade = table.Column<DateTime>(name: "data_validade", type: "date", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    produtoid = table.Column<int>(name: "produto_id", type: "int", nullable: false),
                    fornecedorid = table.Column<int>(name: "fornecedor_id", type: "int", nullable: false),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lotes");
        }
    }
}
