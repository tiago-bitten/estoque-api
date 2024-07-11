using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FIX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_estoques_insumos_insumo_id",
                table: "estoques_insumos");

            migrationBuilder.DropIndex(
                name: "IX_estoques_produto_id",
                table: "estoques");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "lotes_produtos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_fabricacao",
                table: "lotes_produtos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "lotes_insumos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_fabricacao",
                table: "lotes_insumos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_estoques_insumos_insumo_id",
                table: "estoques_insumos",
                column: "insumo_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estoques_produto_id",
                table: "estoques",
                column: "produto_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_estoques_insumos_insumo_id",
                table: "estoques_insumos");

            migrationBuilder.DropIndex(
                name: "IX_estoques_produto_id",
                table: "estoques");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "lotes_produtos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_fabricacao",
                table: "lotes_produtos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_validade",
                table: "lotes_insumos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_fabricacao",
                table: "lotes_insumos",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_estoques_insumos_insumo_id",
                table: "estoques_insumos",
                column: "insumo_id");

            migrationBuilder.CreateIndex(
                name: "IX_estoques_produto_id",
                table: "estoques",
                column: "produto_id");
        }
    }
}
