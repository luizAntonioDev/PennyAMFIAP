using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models.Request
{
    public class ProdutoRequest
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal? CashBack { get; set; }
        public byte[] Foto { get; set; }
        public string CodigoBarra { get; set; }
        public decimal? Preco { get; set; }
        public int EstabelecimentoId { get; set; }
    }
}
