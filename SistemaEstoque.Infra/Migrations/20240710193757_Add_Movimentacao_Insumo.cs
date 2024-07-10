using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddMovimentacaoInsumo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoInsumo_empresas_EmpresaId",
                table: "MovimentacaoInsumo");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoInsumo_insumos_InsumoId",
                table: "MovimentacaoInsumo");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoInsumo_lotes_insumos_LoteInsumoId",
                table: "MovimentacaoInsumo");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoInsumo_usuarios_UsuarioId",
                table: "MovimentacaoInsumo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovimentacaoInsumo",
                table: "MovimentacaoInsumo");

            migrationBuilder.RenameTable(
                name: "MovimentacaoInsumo",
                newName: "movimentacoes_insumos");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "movimentacoes_insumos",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "Removido",
                table: "movimentacoes_insumos",
                newName: "removido");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "movimentacoes_insumos",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "Origem",
                table: "movimentacoes_insumos",
                newName: "origem");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "movimentacoes_insumos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "movimentacoes_insumos",
                newName: "usuario_id");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitarioVenda",
                table: "movimentacoes_insumos",
                newName: "preco_unitario_venda");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitarioCusto",
                table: "movimentacoes_insumos",
                newName: "preco_unitario_custo");

            migrationBuilder.RenameColumn(
                name: "LoteInsumoId",
                table: "movimentacoes_insumos",
                newName: "lote_id");

            migrationBuilder.RenameColumn(
                name: "InsumoId",
                table: "movimentacoes_insumos",
                newName: "insumo_id");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "movimentacoes_insumos",
                newName: "empresa_id");

            migrationBuilder.RenameColumn(
                name: "DataMovimentacao",
                table: "movimentacoes_insumos",
                newName: "data_movimentacao");

            migrationBuilder.RenameIndex(
                name: "IX_MovimentacaoInsumo_UsuarioId",
                table: "movimentacoes_insumos",
                newName: "IX_movimentacoes_insumos_usuario_id");

            migrationBuilder.RenameIndex(
                name: "IX_MovimentacaoInsumo_LoteInsumoId",
                table: "movimentacoes_insumos",
                newName: "IX_movimentacoes_insumos_lote_id");

            migrationBuilder.RenameIndex(
                name: "IX_MovimentacaoInsumo_InsumoId",
                table: "movimentacoes_insumos",
                newName: "IX_movimentacoes_insumos_insumo_id");

            migrationBuilder.RenameIndex(
                name: "IX_MovimentacaoInsumo_EmpresaId",
                table: "movimentacoes_insumos",
                newName: "IX_movimentacoes_insumos_empresa_id");

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "movimentacoes_insumos",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "movimentacoes_insumos",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "movimentacoes_insumos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "origem",
                table: "movimentacoes_insumos",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "movimentacoes_insumos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<decimal>(
                name: "preco_unitario_venda",
                table: "movimentacoes_insumos",
                type: "numeric(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "preco_unitario_custo",
                table: "movimentacoes_insumos",
                type: "numeric(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_movimentacao",
                table: "movimentacoes_insumos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movimentacoes_insumos",
                table: "movimentacoes_insumos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_insumos_empresas_empresa_id",
                table: "movimentacoes_insumos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_insumos_insumos_insumo_id",
                table: "movimentacoes_insumos",
                column: "insumo_id",
                principalTable: "insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_insumos_lotes_insumos_lote_id",
                table: "movimentacoes_insumos",
                column: "lote_id",
                principalTable: "lotes_insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_movimentacoes_insumos_usuarios_usuario_id",
                table: "movimentacoes_insumos",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_insumos_empresas_empresa_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_insumos_insumos_insumo_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_insumos_lotes_insumos_lote_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_movimentacoes_insumos_usuarios_usuario_id",
                table: "movimentacoes_insumos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movimentacoes_insumos",
                table: "movimentacoes_insumos");

            migrationBuilder.RenameTable(
                name: "movimentacoes_insumos",
                newName: "MovimentacaoInsumo");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "MovimentacaoInsumo",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "removido",
                table: "MovimentacaoInsumo",
                newName: "Removido");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "MovimentacaoInsumo",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "origem",
                table: "MovimentacaoInsumo",
                newName: "Origem");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MovimentacaoInsumo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "MovimentacaoInsumo",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "preco_unitario_venda",
                table: "MovimentacaoInsumo",
                newName: "PrecoUnitarioVenda");

            migrationBuilder.RenameColumn(
                name: "preco_unitario_custo",
                table: "MovimentacaoInsumo",
                newName: "PrecoUnitarioCusto");

            migrationBuilder.RenameColumn(
                name: "lote_id",
                table: "MovimentacaoInsumo",
                newName: "LoteInsumoId");

            migrationBuilder.RenameColumn(
                name: "insumo_id",
                table: "MovimentacaoInsumo",
                newName: "InsumoId");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "MovimentacaoInsumo",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "data_movimentacao",
                table: "MovimentacaoInsumo",
                newName: "DataMovimentacao");

            migrationBuilder.RenameIndex(
                name: "IX_movimentacoes_insumos_usuario_id",
                table: "MovimentacaoInsumo",
                newName: "IX_MovimentacaoInsumo_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_movimentacoes_insumos_lote_id",
                table: "MovimentacaoInsumo",
                newName: "IX_MovimentacaoInsumo_LoteInsumoId");

            migrationBuilder.RenameIndex(
                name: "IX_movimentacoes_insumos_insumo_id",
                table: "MovimentacaoInsumo",
                newName: "IX_MovimentacaoInsumo_InsumoId");

            migrationBuilder.RenameIndex(
                name: "IX_movimentacoes_insumos_empresa_id",
                table: "MovimentacaoInsumo",
                newName: "IX_MovimentacaoInsumo_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "MovimentacaoInsumo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "Removido",
                table: "MovimentacaoInsumo",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "MovimentacaoInsumo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Origem",
                table: "MovimentacaoInsumo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MovimentacaoInsumo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitarioVenda",
                table: "MovimentacaoInsumo",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitarioCusto",
                table: "MovimentacaoInsumo",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataMovimentacao",
                table: "MovimentacaoInsumo",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovimentacaoInsumo",
                table: "MovimentacaoInsumo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoInsumo_empresas_EmpresaId",
                table: "MovimentacaoInsumo",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoInsumo_insumos_InsumoId",
                table: "MovimentacaoInsumo",
                column: "InsumoId",
                principalTable: "insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoInsumo_lotes_insumos_LoteInsumoId",
                table: "MovimentacaoInsumo",
                column: "LoteInsumoId",
                principalTable: "lotes_insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoInsumo_usuarios_UsuarioId",
                table: "MovimentacaoInsumo",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
