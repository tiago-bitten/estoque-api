using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTabelaRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    varchar50 = table.Column<string>(name: "varchar(50)", type: "text", nullable: false),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "int", nullable: false),
                    expiraem = table.Column<DateTime>(name: "expira_em", type: "date", nullable: false),
                    isrevogado = table.Column<bool>(name: "is_revogado", type: "boolean", nullable: false, defaultValue: false),
                    ultimageracao = table.Column<DateTime>(name: "ultima_geracao", type: "date", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_refresh_tokens_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_refresh_tokens_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_empresa_id",
                table: "refresh_tokens",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_usuario_id",
                table: "refresh_tokens",
                column: "usuario_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refresh_tokens");
        }
    }
}
