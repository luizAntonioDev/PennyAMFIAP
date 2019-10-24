using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models.Request
{
    public class ProdutoCarrinhoRequest
    {
        public int CarrinhoId { get; set; }
        public int ProdutoId { get; set; }
    }
}
