using Microsoft.EntityFrameworkCore;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Context
{
    public class PennyContext : DbContext
    {
        public PennyContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Acesso> Acessos { get; set; }
        public DbSet<CarrinhoCompra> CarrinhoCompras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



    }
}
