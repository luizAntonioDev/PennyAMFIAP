using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class ContaBancaria
    {
        public  int ContaBancariaId { get; set; }
        public  int BancoId { get; set; }
        public  Banco Banco { get; set; }
        public  string Descricao { get; set; }
        public  string AgenciaCodigo { get; set; }
        public  string AgenciaDigito { get; set; }
        public  string ContaCodigo { get; set; }
        public  string ContaDigito { get; set; }
        public Cliente Titular { get; set; }
    }
}
