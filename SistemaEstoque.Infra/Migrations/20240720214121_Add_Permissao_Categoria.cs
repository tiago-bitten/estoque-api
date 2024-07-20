using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissaoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_produtos_empresas_empresa_id",
                table: "permissoes_produtos");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "perfis_acessos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "PermissaoCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Removido = table.Column<bool>(type: "boolean", nullable: true),
                    PerfilAcessoId = table.Column<int>(type: "integer", nullable: false),
                    Visualizar = table.Column<bool>(type: "boolean", nullable: false),
                    Criar = table.Column<bool>(type: "boolean", nullable: false),
                    Editar = table.Column<bool>(type: "boolean", nullable: false),
                    Excluir = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissaoCategoria_empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoCategoria_EmpresaId",
                table: "PermissaoCategoria",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_perfis_acessos_PermissaoCategoria_id",
                table: "perfis_acessos",
                column: "id",
                principalTable: "PermissaoCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_produtos_empresas_empresa_id",
                table: "permissoes_produtos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_perfis_acessos_PermissaoCategoria_id",
                table: "perfis_acessos");

            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_produtos_empresas_empresa_id",
                table: "permissoes_produtos");

            migrationBuilder.DropTable(
                name: "PermissaoCategoria");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "perfis_acessos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_produtos_empresas_empresa_id",
                table: "permissoes_produtos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
