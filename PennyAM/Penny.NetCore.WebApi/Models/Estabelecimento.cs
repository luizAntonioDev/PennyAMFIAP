using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models
{
    public class Estabelecimento 
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
