using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class adicionadopermissaoparainsumos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_perfil_acesso_id",
                table: "permissoes_categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_produtos_perfis_acessos_perfil_acesso_id",
                table: "permissoes_produtos");

            migrationBuilder.CreateTable(
                name: "permissoes_insumos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    perfilacessoid = table.Column<int>(name: "perfil_acesso_id", type: "int", nullable: false),
                    visualizar = table.Column<bool>(type: "boolean", nullable: false),
                    criar = table.Column<bool>(type: "boolean", nullable: false),
                    editar = table.Column<bool>(type: "boolean", nullable: false),
                    excluir = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissoes_insumos", x => x.id);
                    table.ForeignKey(
                        name: "FK_permissoes_insumos_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_permissoes_insumos_perfis_acessos_perfil_acesso_id",
                        column: x => x.perfilacessoid,
                        principalTable: "perfis_acessos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permissoes_insumos_empresa_id",
                table: "permissoes_insumos",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_permissoes_insumos_perfil_acesso_id",
                table: "permissoes_insumos",
                column: "perfil_acesso_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_perfil_acesso_id",
                table: "permissoes_categorias",
                column: "perfil_acesso_id",
                principalTable: "perfis_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_produtos_perfis_acessos_perfil_acesso_id",
                table: "permissoes_produtos",
                column: "perfil_acesso_id",
                principalTable: "perfis_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_perfil_acesso_id",
                table: "permissoes_categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_produtos_perfis_acessos_perfil_acesso_id",
                table: "permissoes_produtos");

            migrationBuilder.DropTable(
                name: "permissoes_insumos");

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_perfil_acesso_id",
                table: "permissoes_categorias",
                column: "perfil_acesso_id",
                principalTable: "perfis_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_produtos_perfis_acessos_perfil_acesso_id",
                table: "permissoes_produtos",
                column: "perfil_acesso_id",
                principalTable: "perfis_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
