﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Penny.NetCore.WebApi.Context;

namespace Penny.NetCore.WebApi.Migrations
{
    [DbContext(typeof(PennyContext))]
    [Migration("20191024061918_Inicio_V2")]
    partial class Inicio_V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Acesso", b =>
                {
                    b.Property<int>("AcessoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Senha");

                    b.Property<int>("Tipo");

                    b.HasKey("AcessoId");

                    b.ToTable("Acessos");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.CarrinhoCompra", b =>
                {
                    b.Property<int>("CarrinhoCompraId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("DataCarrinho");

                    b.HasKey("CarrinhoCompraId");

                    b.HasIndex("ClienteId");

                    b.ToTable("CarrinhoCompras");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("CashDisponivel");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<string>("Documento");

                    b.Property<int?>("EnderecoId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("ClienteId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Compra", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarrinhoCompraId");

                    b.Property<DateTime>("DataCompra");

                    b.Property<int?>("UnidadeId");

                    b.Property<decimal>("ValorTotal");

                    b.HasKey("CompraId");

                    b.HasIndex("CarrinhoCompraId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep");

                    b.Property<string>("Cidade");

                    b.Property<string>("Estado");

                    b.Property<string>("Logradouro");

                    b.Property<int>("Numero");

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Estabelecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao");

                    b.Property<int?>("EnderecoId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Estabelecimentos");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("CashBack");

                    b.Property<string>("CodigoBarra");

                    b.Property<string>("Descricao");

                    b.Property<int>("EstabelecimentoId");

                    b.Property<byte[]>("Foto");

                    b.Property<string>("Nome");

                    b.Property<decimal?>("Preco");

                    b.HasKey("ProdutoId");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.ProdutoCarrinho", b =>
                {
                    b.Property<int>("ProdutoCarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarrinhoCompraId");

                    b.Property<int?>("ProdutoId");

                    b.HasKey("ProdutoCarrinhoId");

                    b.HasIndex("CarrinhoCompraId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoCarrinho");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcessoId");

                    b.Property<byte[]>("Foto");

                    b.Property<string>("Nome");

                    b.HasKey("UsuarioId");

                    b.HasIndex("AcessoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.CarrinhoCompra", b =>
                {
                    b.HasOne("Penny.NetCore.WebApi.Models.Cliente", "Cliente")
                        .WithMany("CarrinhosCompras")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Cliente", b =>
                {
                    b.HasOne("Penny.NetCore.WebApi.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("Penny.NetCore.WebApi.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Compra", b =>
                {
                    b.HasOne("Penny.NetCore.WebApi.Models.CarrinhoCompra", "CarrinhoCompra")
                        .WithMany()
                        .HasForeignKey("CarrinhoCompraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Penny.NetCore.WebApi.Models.Estabelecimento", "Unidade")
                        .WithMany()
                        .HasForeignKey("UnidadeId");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Estabelecimento", b =>
                {
                    b.HasOne("Penny.NetCore.WebApi.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("Penny.NetCore.WebApi.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Produto", b =>
                {
                    b.HasOne("Penny.NetCore.WebApi.Models.Estabelecimento", "Estabelecimento")
                        .WithMany()
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.ProdutoCarrinho", b =>
                {
                    b.HasOne("Penny.NetCore.WebApi.Models.CarrinhoCompra", "CarrinhoCompra")
                        .WithMany("ProdutosCarrinho")
                        .HasForeignKey("CarrinhoCompraId");

                    b.HasOne("Penny.NetCore.WebApi.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("Penny.NetCore.WebApi.Models.Usuario", b =>
                {
                    b.HasOne("Penny.NetCore.WebApi.Models.Acesso", "Acesso")
                        .WithMany()
                        .HasForeignKey("AcessoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
