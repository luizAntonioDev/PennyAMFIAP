using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime DataCompra { get; set; }
        public Estabelecimento Unidade { get; set; }
        public decimal ValorTotal { get; set; }
        public int CarrinhoCompraId { get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; }

    }
}
