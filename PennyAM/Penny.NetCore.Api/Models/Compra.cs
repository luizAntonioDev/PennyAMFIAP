using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime DataCompra { get; set; }
        public List<Produto> Produtos { get; set; }
        public Estabelecimento Unidade { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
