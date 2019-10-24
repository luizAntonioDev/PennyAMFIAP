using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models
{
    public class CarrinhoCompra
    {
        public int CarrinhoCompraId { get; set; }
        public List<ProdutoCarrinho> ProdutosCarrinho { get; set; }
        public DateTime DataCarrinho { get; set; }
        public bool Ativo { get; set; }
        public Cliente Cliente { get; set; }

    }
}
