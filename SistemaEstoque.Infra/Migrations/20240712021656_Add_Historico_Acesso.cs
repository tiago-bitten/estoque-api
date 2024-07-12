using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoricoAcesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoUsuarioAcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DataAcesso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IpAcesso = table.Column<string>(type: "text", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false),
                    AcessoValido = table.Column<bool>(type: "boolean", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoUsuarioAcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoUsuarioAcesso_empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HistoricoUsuarioAcesso_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoUsuarioAcesso_EmpresaId",
                table: "HistoricoUsuarioAcesso",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoUsuarioAcesso_UsuarioId",
                table: "HistoricoUsuarioAcesso",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoUsuarioAcesso");
        }
    }
}
