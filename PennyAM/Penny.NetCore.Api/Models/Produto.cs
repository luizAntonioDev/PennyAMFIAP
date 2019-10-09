using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal CashBack { get; set; }
        public byte[] Foto { get; set; }
        public int CodigoBarra { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

    }
}
