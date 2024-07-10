using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddLoteInsumo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoteInsumo_empresas_EmpresaId",
                table: "LoteInsumo");

            migrationBuilder.DropForeignKey(
                name: "FK_LoteInsumo_fornecedores_FornecedorId",
                table: "LoteInsumo");

            migrationBuilder.DropForeignKey(
                name: "FK_LoteInsumo_insumos_InsumoId",
                table: "LoteInsumo");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoInsumo_LoteInsumo_LoteInsumoId",
                table: "MovimentacaoInsumo");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoInsumo_empresas_EmpresaId",
                table: "MovimentacaoInsumo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoteInsumo",
                table: "LoteInsumo");

            migrationBuilder.RenameTable(
                name: "LoteInsumo",
                newName: "lotes_insumos");

            migrationBuilder.RenameColumn(
                name: "Removido",
                table: "lotes_insumos",
                newName: "removido");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "lotes_insumos",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "lotes_insumos",
                newName: "codigo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "lotes_insumos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "InsumoId",
                table: "lotes_insumos",
                newName: "insumo_id");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "lotes_insumos",
                newName: "fornecedor_id");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "lotes_insumos",
                newName: "empresa_id");

            migrationBuilder.RenameColumn(
                name: "DataValidade",
                table: "lotes_insumos",
                newName: "data_validade");

            migrationBuilder.RenameColumn(
                name: "DataFabricacao",
                table: "lotes_insumos",
                newName: "data_fabricacao");

            migrationBuilder.RenameColumn(
                name: "CodigoBarras",
                table: "lotes_insumos",
                newName: "codigo_barras");

            migrationBuilder.RenameIndex(
                name: "IX_LoteInsumo_InsumoId",
                table: "lotes_insumos",
                newName: "IX_lotes_insumos_insumo_id");

            migrationBuilder.RenameIndex(
                name: "IX_LoteInsumo_FornecedorId",
                table: "lotes_insumos",
                newName: "IX_lotes_insumos_fornecedor_id");

            migrationBuilder.RenameIndex(
                name: "IX_LoteInsumo_EmpresaId",
                table: "lotes_insumos",
                newName: "IX_lotes_insumos_empresa_id");

            migrationBuilder.AlterColumn<int>(
                name: "LoteInsumoId",
                table: "MovimentacaoInsumo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "lotes_insumos",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "lotes_insumos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "lotes_insumos",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "lotes_insumos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "lotes_insumos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_fabricacao",
                table: "lotes_insumos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "codigo_barras",
                table: "lotes_insumos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lotes_insumos",
                table: "lotes_insumos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_lotes_insumos_empresas_empresa_id",
                table: "lotes_insumos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_lotes_insumos_fornecedores_fornecedor_id",
                table: "lotes_insumos",
                column: "fornecedor_id",
                principalTable: "fornecedores",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_lotes_insumos_insumos_insumo_id",
                table: "lotes_insumos",
                column: "insumo_id",
                principalTable: "insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoInsumo_empresas_EmpresaId",
                table: "MovimentacaoInsumo",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoInsumo_lotes_insumos_LoteInsumoId",
                table: "MovimentacaoInsumo",
                column: "LoteInsumoId",
                principalTable: "lotes_insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lotes_insumos_empresas_empresa_id",
                table: "lotes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_lotes_insumos_fornecedores_fornecedor_id",
                table: "lotes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_lotes_insumos_insumos_insumo_id",
                table: "lotes_insumos");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoInsumo_empresas_EmpresaId",
                table: "MovimentacaoInsumo");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoInsumo_lotes_insumos_LoteInsumoId",
                table: "MovimentacaoInsumo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_lotes_insumos",
                table: "lotes_insumos");

            migrationBuilder.RenameTable(
                name: "lotes_insumos",
                newName: "LoteInsumo");

            migrationBuilder.RenameColumn(
                name: "removido",
                table: "LoteInsumo",
                newName: "Removido");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "LoteInsumo",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "LoteInsumo",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LoteInsumo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "insumo_id",
                table: "LoteInsumo",
                newName: "InsumoId");

            migrationBuilder.RenameColumn(
                name: "fornecedor_id",
                table: "LoteInsumo",
                newName: "FornecedorId");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "LoteInsumo",
                newName: "EmpresaId");

            migrationBuilder.RenameColumn(
                name: "data_validade",
                table: "LoteInsumo",
                newName: "DataValidade");

            migrationBuilder.RenameColumn(
                name: "data_fabricacao",
                table: "LoteInsumo",
                newName: "DataFabricacao");

            migrationBuilder.RenameColumn(
                name: "codigo_barras",
                table: "LoteInsumo",
                newName: "CodigoBarras");

            migrationBuilder.RenameIndex(
                name: "IX_lotes_insumos_insumo_id",
                table: "LoteInsumo",
                newName: "IX_LoteInsumo_InsumoId");

            migrationBuilder.RenameIndex(
                name: "IX_lotes_insumos_fornecedor_id",
                table: "LoteInsumo",
                newName: "IX_LoteInsumo_FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_lotes_insumos_empresa_id",
                table: "LoteInsumo",
                newName: "IX_LoteInsumo_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "LoteInsumoId",
                table: "MovimentacaoInsumo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Removido",
                table: "LoteInsumo",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "LoteInsumo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "LoteInsumo",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LoteInsumo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidade",
                table: "LoteInsumo",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFabricacao",
                table: "LoteInsumo",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarras",
                table: "LoteInsumo",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoteInsumo",
                table: "LoteInsumo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoteInsumo_empresas_EmpresaId",
                table: "LoteInsumo",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoteInsumo_fornecedores_FornecedorId",
                table: "LoteInsumo",
                column: "FornecedorId",
                principalTable: "fornecedores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoteInsumo_insumos_InsumoId",
                table: "LoteInsumo",
                column: "InsumoId",
                principalTable: "insumos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoInsumo_LoteInsumo_LoteInsumoId",
                table: "MovimentacaoInsumo",
                column: "LoteInsumoId",
                principalTable: "LoteInsumo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoInsumo_empresas_EmpresaId",
                table: "MovimentacaoInsumo",
                column: "EmpresaId",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
