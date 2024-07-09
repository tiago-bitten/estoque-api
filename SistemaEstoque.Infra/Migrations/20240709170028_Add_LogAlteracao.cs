using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddLogAlteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logs_alteracoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tabela = table.Column<string>(type: "varchar(50)", nullable: false),
                    alteradoem = table.Column<DateTime>(name: "alterado_em", type: "date", nullable: false),
                    itemid = table.Column<int>(name: "item_id", type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    dadosantigos = table.Column<string>(name: "dados_antigos", type: "jsonb", nullable: false),
                    dadosnovos = table.Column<string>(name: "dados_novos", type: "jsonb", nullable: false),
                    tipo = table.Column<string>(type: "text", nullable: false),
                    usuarioid = table.Column<int>(name: "usuario_id", type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs_alteracoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_logs_alteracoes_empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_logs_alteracoes_usuarios_usuario_id",
                        column: x => x.usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_logs_alteracoes_EmpresaId",
                table: "logs_alteracoes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_logs_alteracoes_usuario_id",
                table: "logs_alteracoes",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs_alteracoes");
        }
    }
}
