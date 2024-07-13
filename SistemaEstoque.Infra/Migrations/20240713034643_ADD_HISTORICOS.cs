using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ADDHISTORICOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "historicos_estoques_insumos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    estoqueinsumoid = table.Column<int>(name: "estoque_insumo_id", type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    dataregistro = table.Column<DateTime>(name: "data_registro", type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicos_estoques_insumos", x => x.id);
                    table.ForeignKey(
                        name: "FK_historicos_estoques_insumos_empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_historicos_estoques_insumos_estoques_insumos_estoque_insumo~",
                        column: x => x.estoqueinsumoid,
                        principalTable: "estoques_insumos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "historicos_estoques_produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    estoqueprodutoid = table.Column<int>(name: "estoque_produto_id", type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    dataregistro = table.Column<DateTime>(name: "data_registro", type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historicos_estoques_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_historicos_estoques_produtos_empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_historicos_estoques_produtos_estoques_estoque_produto_id",
                        column: x => x.estoqueprodutoid,
                        principalTable: "estoques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historicos_estoques_insumos_EmpresaId",
                table: "historicos_estoques_insumos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_historicos_estoques_insumos_estoque_insumo_id",
                table: "historicos_estoques_insumos",
                column: "estoque_insumo_id");

            migrationBuilder.CreateIndex(
                name: "IX_historicos_estoques_produtos_EmpresaId",
                table: "historicos_estoques_produtos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_historicos_estoques_produtos_estoque_produto_id",
                table: "historicos_estoques_produtos",
                column: "estoque_produto_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historicos_estoques_insumos");

            migrationBuilder.DropTable(
                name: "historicos_estoques_produtos");
        }
    }
}
