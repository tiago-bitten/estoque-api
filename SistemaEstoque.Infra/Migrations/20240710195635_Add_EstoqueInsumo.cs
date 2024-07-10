using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddEstoqueInsumo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estoques_insumos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    insumoid = table.Column<int>(name: "insumo_id", type: "int", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: true, defaultValue: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    quantidademinima = table.Column<int>(name: "quantidade_minima", type: "int", nullable: false),
                    quantidademaxima = table.Column<int>(name: "quantidade_maxima", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoques_insumos", x => x.id);
                    table.ForeignKey(
                        name: "FK_estoques_insumos_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_estoques_insumos_insumos_insumo_id",
                        column: x => x.insumoid,
                        principalTable: "insumos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estoques_insumos_empresa_id",
                table: "estoques_insumos",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_estoques_insumos_insumo_id",
                table: "estoques_insumos",
                column: "insumo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estoques_insumos");
        }
    }
}
