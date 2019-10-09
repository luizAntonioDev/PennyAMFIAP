using Microsoft.EntityFrameworkCore;
using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Context
{
    public class PennyContext : DbContext
    {
        public DbSet<Acesso> Acessos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<CarrinhoCompra> CarrinhoCompras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ContaBancaria> ContaBancarias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public PennyContext(DbContextOptions options) : base(options)
        {
        
        }

    }
}
