using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class CarrinhoCompra
    {
        public int CarrinhoCompraId { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime DataCarrinho { get; set; }
        public bool Ativo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
