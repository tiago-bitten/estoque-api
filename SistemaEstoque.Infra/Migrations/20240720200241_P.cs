using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class P : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresas_Proprietario_proprietario_id",
                table: "empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proprietario",
                table: "Proprietario");

            migrationBuilder.RenameTable(
                name: "Proprietario",
                newName: "proprietarios");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "proprietarios",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "Removido",
                table: "proprietarios",
                newName: "removido");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "proprietarios",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "proprietarios",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "proprietarios",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "proprietarios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "proprietarios",
                newName: "data_nascimento");

            migrationBuilder.AlterColumn<string>(
                name: "telefone",
                table: "proprietarios",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "removido",
                table: "proprietarios",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "proprietarios",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "proprietarios",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "proprietarios",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "proprietarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_nascimento",
                table: "proprietarios",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_proprietarios",
                table: "proprietarios",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_proprietarios_proprietario_id",
                table: "empresas",
                column: "proprietario_id",
                principalTable: "proprietarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresas_proprietarios_proprietario_id",
                table: "empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proprietarios",
                table: "proprietarios");

            migrationBuilder.RenameTable(
                name: "proprietarios",
                newName: "Proprietario");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Proprietario",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "removido",
                table: "Proprietario",
                newName: "Removido");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Proprietario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Proprietario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Proprietario",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Proprietario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "Proprietario",
                newName: "DataNascimento");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Proprietario",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<bool>(
                name: "Removido",
                table: "Proprietario",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Proprietario",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Proprietario",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Proprietario",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Proprietario",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Proprietario",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proprietario",
                table: "Proprietario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_Proprietario_proprietario_id",
                table: "empresas",
                column: "proprietario_id",
                principalTable: "Proprietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
