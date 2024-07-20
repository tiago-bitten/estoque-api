using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddProprietario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "proprietario_id",
                table: "empresas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empresas_proprietario_id",
                table: "empresas",
                column: "proprietario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_Proprietario_proprietario_id",
                table: "empresas",
                column: "proprietario_id",
                principalTable: "Proprietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresas_Proprietario_proprietario_id",
                table: "empresas");

            migrationBuilder.DropTable(
                name: "Proprietario");

            migrationBuilder.DropIndex(
                name: "IX_empresas_proprietario_id",
                table: "empresas");

            migrationBuilder.DropColumn(
                name: "proprietario_id",
                table: "empresas");
        }
    }
}
