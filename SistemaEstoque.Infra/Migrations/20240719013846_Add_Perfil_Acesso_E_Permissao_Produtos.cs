using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPerfilAcessoEPermissaoProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "perfil_acesso_id",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "perfis_acessos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfis_acessos", x => x.id);
                    table.ForeignKey(
                        name: "FK_perfis_acessos_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "permissoes_produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    perfilacessoid = table.Column<int>(name: "perfil_acesso_id", type: "int", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: false),
                    visualizar = table.Column<bool>(type: "boolean", nullable: false),
                    criar = table.Column<bool>(type: "boolean", nullable: false),
                    editar = table.Column<bool>(type: "boolean", nullable: false),
                    excluir = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissoes_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_permissoes_produtos_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permissoes_produtos_perfis_acessos_perfil_acesso_id",
                        column: x => x.perfilacessoid,
                        principalTable: "perfis_acessos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_perfil_acesso_id",
                table: "usuarios",
                column: "perfil_acesso_id");

            migrationBuilder.CreateIndex(
                name: "IX_perfis_acessos_empresa_id",
                table: "perfis_acessos",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissoes_produtos_empresa_id",
                table: "permissoes_produtos",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissoes_produtos_perfil_acesso_id",
                table: "permissoes_produtos",
                column: "perfil_acesso_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_perfis_acessos_perfil_acesso_id",
                table: "usuarios",
                column: "perfil_acesso_id",
                principalTable: "perfis_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_perfis_acessos_perfil_acesso_id",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "permissoes_produtos");

            migrationBuilder.DropTable(
                name: "perfis_acessos");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_perfil_acesso_id",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "perfil_acesso_id",
                table: "usuarios");
        }
    }
}
