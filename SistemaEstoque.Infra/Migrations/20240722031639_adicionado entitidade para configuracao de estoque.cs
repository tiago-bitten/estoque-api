using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoentitidadeparaconfiguracaodeestoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfiguracaoEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PermiteEstoqueNegativo = table.Column<bool>(type: "boolean", nullable: false),
                    PermitePassarEstoqueMinimo = table.Column<bool>(type: "boolean", nullable: false),
                    PermitePassarEstoqueMaximo = table.Column<bool>(type: "boolean", nullable: false),
                    NotificarEstoqueMinimo = table.Column<bool>(type: "boolean", nullable: false),
                    NotificarEstoqueMaximo = table.Column<bool>(type: "boolean", nullable: false),
                    PermiteSaidaSemLote = table.Column<bool>(type: "boolean", nullable: false),
                    PermiteEntradaSemLote = table.Column<bool>(type: "boolean", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoEstoque_empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoEstoque_EmpresaId",
                table: "ConfiguracaoEstoque",
                column: "EmpresaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracaoEstoque");
        }
    }
}
