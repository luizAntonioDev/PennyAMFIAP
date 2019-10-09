using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class Banco
    {
        public int BancoId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}
