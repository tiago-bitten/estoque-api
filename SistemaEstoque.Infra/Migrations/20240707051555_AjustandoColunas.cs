using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Empresas_EmpresaId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Empresas_EmpresaId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Empresas_EmpresaId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "produtos");

            migrationBuilder.RenameTable(
                name: "Empresas",
                newName: "empresas");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "categorias");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "usuarios",
                newName: "empresa_id");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "usuarios",
                newName: "IX_usuarios_empresa_id");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "produtos",
                newName: "empresa_id");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "produtos",
                newName: "categoria_id");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_EmpresaId",
                table: "produtos",
                newName: "IX_produtos_empresa_id");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaId",
                table: "produtos",
                newName: "IX_produtos_categoria_id");

            migrationBuilder.RenameIndex(
                name: "IX_Categorias_EmpresaId",
                table: "categorias",
                newName: "IX_categorias_EmpresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produtos",
                table: "produtos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_empresas",
                table: "empresas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categorias",
                table: "categorias",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_categorias_empresas_EmpresaId",
                table: "categorias",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_categorias_categoria_id",
                table: "produtos",
                column: "categoria_id",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_empresas_empresa_id",
                table: "produtos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_empresas_empresa_id",
                table: "usuarios",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorias_empresas_EmpresaId",
                table: "categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_categorias_categoria_id",
                table: "produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_empresas_empresa_id",
                table: "produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_empresas_empresa_id",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produtos",
                table: "produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_empresas",
                table: "empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categorias",
                table: "categorias");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "produtos",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "empresas",
                newName: "Empresas");

            migrationBuilder.RenameTable(
                name: "categorias",
                newName: "Categorias");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "Usuarios",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_empresa_id",
                table: "Usuarios",
                newName: "IX_Usuarios_EmpresaId");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "Items",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "categoria_id",
                table: "Items",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_produtos_empresa_id",
                table: "Items",
                newName: "IX_Produtos_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_produtos_categoria_id",
                table: "Items",
                newName: "IX_Produtos_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_categorias_EmpresaId",
                table: "Categorias",
                newName: "IX_Categorias_EmpresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Items",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Empresas_EmpresaId",
                table: "Categorias",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Items",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Empresas_EmpresaId",
                table: "Items",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Empresas_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
