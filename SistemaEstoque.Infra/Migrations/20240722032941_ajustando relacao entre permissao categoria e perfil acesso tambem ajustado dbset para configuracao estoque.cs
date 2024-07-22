using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajustandorelacaoentrepermissaocategoriaeperfilacessotambemajustadodbsetparaconfiguracaoestoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracaoEstoque_empresas_EmpresaId",
                table: "ConfiguracaoEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_Id",
                table: "permissoes_categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfiguracaoEstoque",
                table: "ConfiguracaoEstoque");

            migrationBuilder.RenameTable(
                name: "ConfiguracaoEstoque",
                newName: "configuracoes_estoques");

            migrationBuilder.RenameColumn(
                name: "Removido",
                table: "configuracoes_estoques",
                newName: "removido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "configuracoes_estoques",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PermiteSaidaSemLote",
                table: "configuracoes_estoques",
                newName: "permite_saida_sem_lote");

            migrationBuilder.RenameColumn(
                name: "PermitePassarEstoqueMinimo",
                table: "configuracoes_estoques",
                newName: "permite_passar_estoque_minimo");

            migrationBuilder.RenameColumn(
                name: "PermitePassarEstoqueMaximo",
                table: "configuracoes_estoques",
                newName: "permite_passar_estoque_maximo");

            migrationBuilder.RenameColumn(
                name: "PermiteEstoqueNegativo",
                table: "configuracoes_estoques",
                newName: "permite_estoque_negativo");

            migrationBuilder.RenameColumn(
                name: "PermiteEntradaSemLote",
                table: "configuracoes_estoques",
                newName: "permite_entrada_sem_lote");

            migrationBuilder.RenameColumn(
                name: "NotificarEstoqueMinimo",
                table: "configuracoes_estoques",
                newName: "notificar_estoque_minimo");

            migrationBuilder.RenameColumn(
                name: "NotificarEstoqueMaximo",
                table: "configuracoes_estoques",
                newName: "notificar_estoque_maximo");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "configuracoes_estoques",
                newName: "empresa_id");

            migrationBuilder.RenameIndex(
                name: "IX_ConfiguracaoEstoque_EmpresaId",
                table: "configuracoes_estoques",
                newName: "IX_configuracoes_estoques_empresa_id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "permissoes_categorias",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "configuracoes_estoques",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "configuracoes_estoques",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_configuracoes_estoques",
                table: "configuracoes_estoques",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_permissoes_categorias_perfil_acesso_id",
                table: "permissoes_categorias",
                column: "perfil_acesso_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_configuracoes_estoques_empresas_empresa_id",
                table: "configuracoes_estoques",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_perfil_acesso_id",
                table: "permissoes_categorias",
                column: "perfil_acesso_id",
                principalTable: "perfis_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_configuracoes_estoques_empresas_empresa_id",
                table: "configuracoes_estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_perfil_acesso_id",
                table: "permissoes_categorias");

            migrationBuilder.DropIndex(
                name: "IX_permissoes_categorias_perfil_acesso_id",
                table: "permissoes_categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_configuracoes_estoques",
                table: "configuracoes_estoques");

            migrationBuilder.RenameTable(
                name: "configuracoes_estoques",
                newName: "ConfiguracaoEstoque");

            migrationBuilder.RenameColumn(
                name: "removido",
                table: "ConfiguracaoEstoque",
                newName: "Removido");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ConfiguracaoEstoque",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "permite_saida_sem_lote",
                table: "ConfiguracaoEstoque",
                newName: "PermiteSaidaSemLote");

            migrationBuilder.RenameColumn(
                name: "permite_passar_estoque_minimo",
                table: "ConfiguracaoEstoque",
                newName: "PermitePassarEstoqueMinimo");

            migrationBuilder.RenameColumn(
                name: "permite_passar_estoque_maximo",
                table: "ConfiguracaoEstoque",
                newName: "PermitePassarEstoqueMaximo");

            migrationBuilder.RenameColumn(
                name: "permite_estoque_negativo",
                table: "ConfiguracaoEstoque",
                newName: "PermiteEstoqueNegativo");

            migrationBuilder.RenameColumn(
                name: "permite_entrada_sem_lote",
                table: "ConfiguracaoEstoque",
                newName: "PermiteEntradaSemLote");

            migrationBuilder.RenameColumn(
                name: "notificar_estoque_minimo",
                table: "ConfiguracaoEstoque",
                newName: "NotificarEstoqueMinimo");

            migrationBuilder.RenameColumn(
                name: "notificar_estoque_maximo",
                table: "ConfiguracaoEstoque",
                newName: "NotificarEstoqueMaximo");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "ConfiguracaoEstoque",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_configuracoes_estoques_empresa_id",
                table: "ConfiguracaoEstoque",
                newName: "IX_ConfiguracaoEstoque_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "permissoes_categorias",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "Removido",
                table: "ConfiguracaoEstoque",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ConfiguracaoEstoque",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfiguracaoEstoque",
                table: "ConfiguracaoEstoque",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracaoEstoque_empresas_EmpresaId",
                table: "ConfiguracaoEstoque",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_permissoes_categorias_perfis_acessos_Id",
                table: "permissoes_categorias",
                column: "Id",
                principalTable: "perfis_acessos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
