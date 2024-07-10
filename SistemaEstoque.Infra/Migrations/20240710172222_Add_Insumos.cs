using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddInsumos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "preco_venda_referencia",
                table: "produtos",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.CreateTable(
                name: "insumos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    precocustoreferencia = table.Column<decimal>(name: "preco_custo_referencia", type: "numeric(10,2)", nullable: true),
                    precovendareferencia = table.Column<decimal>(name: "preco_venda_referencia", type: "numeric(10,2)", nullable: true),
                    categoriaid = table.Column<int>(name: "categoria_id", type: "int", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumos", x => x.id);
                    table.ForeignKey(
                        name: "FK_insumos_categorias_categoria_id",
                        column: x => x.categoriaid,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_insumos_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_insumos_categoria_id",
                table: "insumos",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_insumos_empresa_id",
                table: "insumos",
                column: "empresa_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "insumos");

            migrationBuilder.AlterColumn<decimal>(
                name: "preco_venda_referencia",
                table: "produtos",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);
        }
    }
}
