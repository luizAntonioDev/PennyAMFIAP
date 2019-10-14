using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Penny.NetCore.Api.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acessos",
                columns: table => new
                {
                    AcessoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessos", x => x.AcessoId);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Cep = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    AcessoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: false),
                    Foto = table.Column<byte[]>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    Cpf = table.Column<int>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    CashDisponivel = table.Column<decimal>(nullable: true),
                    UnidadeId = table.Column<int>(nullable: true),
                    UsuarioId1 = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Cpnj = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Acessos_AcessoId",
                        column: x => x.AcessoId,
                        principalTable: "Acessos",
                        principalColumn: "AcessoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoCompras",
                columns: table => new
                {
                    CarrinhoCompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCarrinho = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoCompras", x => x.CarrinhoCompraId);
                    table.ForeignKey(
                        name: "FK_CarrinhoCompras_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCompra = table.Column<DateTime>(nullable: false),
                    UnidadeUsuarioId = table.Column<int>(nullable: true),
                    EstabelecimentoUsuarioId = table.Column<int>(nullable: true),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    CarrinhoCompraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compras_CarrinhoCompras_CarrinhoCompraId",
                        column: x => x.CarrinhoCompraId,
                        principalTable: "CarrinhoCompras",
                        principalColumn: "CarrinhoCompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_EstabelecimentoUsuarioId",
                        column: x => x.EstabelecimentoUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_UnidadeUsuarioId",
                        column: x => x.UnidadeUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    CashBack = table.Column<decimal>(nullable: false),
                    Foto = table.Column<byte[]>(nullable: true),
                    CodigoBarra = table.Column<int>(nullable: false),
                    EstabelecimentoId = table.Column<int>(nullable: false),
                    CarrinhoCompraId = table.Column<int>(nullable: true),
                    CompraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_CarrinhoCompras_CarrinhoCompraId",
                        column: x => x.CarrinhoCompraId,
                        principalTable: "CarrinhoCompras",
                        principalColumn: "CarrinhoCompraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Usuarios_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompras_ClienteId",
                table: "CarrinhoCompras",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CarrinhoCompraId",
                table: "Compras",
                column: "CarrinhoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_EstabelecimentoUsuarioId",
                table: "Compras",
                column: "EstabelecimentoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UnidadeUsuarioId",
                table: "Compras",
                column: "UnidadeUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CarrinhoCompraId",
                table: "Produtos",
                column: "CarrinhoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CompraId",
                table: "Produtos",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EstabelecimentoId",
                table: "Produtos",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioId1",
                table: "Usuarios",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AcessoId",
                table: "Usuarios",
                column: "AcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "CarrinhoCompras");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Acessos");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
