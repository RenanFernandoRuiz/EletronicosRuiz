using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EletronicosRuiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class alteracoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeEmEstoque = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<long>(type: "bigint", nullable: false),
                    FornecedorId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId1",
                        column: x => x.FornecedorId1,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendaProduto",
                columns: table => new
                {
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendaId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProdutoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdutoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaProduto", x => x.Quantidade);
                    table.ForeignKey(
                        name: "FK_VendaProduto_Produto_ProdutoId1",
                        column: x => x.ProdutoId1,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendaProduto_Venda_VendaId1",
                        column: x => x.VendaId1,
                        principalTable: "Venda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId1",
                table: "Produto",
                column: "FornecedorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId1",
                table: "Venda",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProduto_ProdutoId1",
                table: "VendaProduto",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProduto_VendaId1",
                table: "VendaProduto",
                column: "VendaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaProduto");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
