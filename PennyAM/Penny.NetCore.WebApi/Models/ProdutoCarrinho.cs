using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models
{
    public class ProdutoCarrinho
    {
        public int ProdutoCarrinhoId { get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public Produto Produto { get; set; }
    }
}
