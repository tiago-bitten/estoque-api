using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ADDEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "preco_venda",
                table: "produtos",
                newName: "preco_venda_referencia");

            migrationBuilder.RenameColumn(
                name: "preco_custo",
                table: "produtos",
                newName: "preco_custo_referencia");

            migrationBuilder.RenameColumn(
                name: "CpfCnpj",
                table: "empresas",
                newName: "cpf_cnpj");

            migrationBuilder.AlterColumn<string>(
                name: "cpf_cnpj",
                table: "empresas",
                type: "varchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14);

            migrationBuilder.CreateTable(
                name: "estoques",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    quantidademinima = table.Column<int>(name: "quantidade_minima", type: "int", nullable: false),
                    quantidademaxima = table.Column<int>(name: "quantidade_maxima", type: "int", nullable: false),
                    produtoid = table.Column<int>(name: "produto_id", type: "int", nullable: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false),
                    removido = table.Column<bool>(type: "BOOLEAN", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estoques", x => x.id);
                    table.ForeignKey(
                        name: "FK_estoques_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_estoques_produtos_produto_id",
                        column: x => x.produtoid,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    cpfcnpj = table.Column<string>(name: "cpf_cnpj", type: "varchar(14)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    endereco = table.Column<string>(type: "varchar(150)", nullable: false),
                    cidade = table.Column<string>(type: "varchar(150)", nullable: false),
                    estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    removido = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    empresaid = table.Column<int>(name: "empresa_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedores", x => x.id);
                    table.ForeignKey(
                        name: "FK_fornecedores_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estoques_empresa_id",
                table: "estoques",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_estoques_produto_id",
                table: "estoques",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_fornecedores_empresa_id",
                table: "fornecedores",
                column: "empresa_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estoques");

            migrationBuilder.DropTable(
                name: "fornecedores");

            migrationBuilder.RenameColumn(
                name: "preco_venda_referencia",
                table: "produtos",
                newName: "preco_venda");

            migrationBuilder.RenameColumn(
                name: "preco_custo_referencia",
                table: "produtos",
                newName: "preco_custo");

            migrationBuilder.RenameColumn(
                name: "cpf_cnpj",
                table: "empresas",
                newName: "CpfCnpj");

            migrationBuilder.AlterColumn<string>(
                name: "CpfCnpj",
                table: "empresas",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)");
        }
    }
}
