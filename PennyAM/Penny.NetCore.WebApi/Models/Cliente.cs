using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal CashDisponivel { get; set; }
        public List<CarrinhoCompra> CarrinhosCompras { get; set; }
        public Endereco Endereco { get; set; }
        public Usuario Usuario { get; set; }

    }
}
