using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Penny.NetCore.WebApi.Models.PennyConfig;

namespace Penny.NetCore.WebApi.Models.Request
{
    public class ClienteRequest
    {
        public int ClienteId { get; set; }
        public string Documento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public decimal? CashDisponivel { get; set; }
        public string Nome { get; set; }

        public byte[] Foto { get; set; }


        public Endereco Endereco { get; set; }
    }
}
