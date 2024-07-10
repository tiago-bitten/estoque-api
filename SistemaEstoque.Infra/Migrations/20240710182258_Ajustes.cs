using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Ajustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "produtos",
                type: "varchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "categorias",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "tipo_item",
                table: "categorias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LoteInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InsumoId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    CodigoBarras = table.Column<string>(type: "text", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoteInsumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoteInsumo_empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoteInsumo_fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "fornecedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoteInsumo_insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "insumos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoInsumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InsumoId = table.Column<int>(type: "int", nullable: false),
                    LoteInsumoId = table.Column<int>(type: "integer", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PrecoUnitarioVenda = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecoUnitarioCusto = table.Column<decimal>(type: "numeric", nullable: false),
                    Origem = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoInsumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacaoInsumo_LoteInsumo_LoteInsumoId",
                        column: x => x.LoteInsumoId,
                        principalTable: "LoteInsumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentacaoInsumo_empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentacaoInsumo_insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "insumos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentacaoInsumo_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoteInsumo_EmpresaId",
                table: "LoteInsumo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_LoteInsumo_FornecedorId",
                table: "LoteInsumo",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_LoteInsumo_InsumoId",
                table: "LoteInsumo",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoInsumo_EmpresaId",
                table: "MovimentacaoInsumo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoInsumo_InsumoId",
                table: "MovimentacaoInsumo",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoInsumo_LoteInsumoId",
                table: "MovimentacaoInsumo",
                column: "LoteInsumoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoInsumo_UsuarioId",
                table: "MovimentacaoInsumo",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacaoInsumo");

            migrationBuilder.DropTable(
                name: "LoteInsumo");

            migrationBuilder.DropColumn(
                name: "tipo_item",
                table: "categorias");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "produtos",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "categorias",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);
        }
    }
}
