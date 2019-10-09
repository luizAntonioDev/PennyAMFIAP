using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class Cliente : Usuario
    {
        public int ClienteId { get; set; }
        public int Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public ContaBancaria Cartao { get; set; }
        public decimal CashDisponivel { get; set; }

    }
}
