using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class Estabelecimento 
    {
        public int UnidadeId { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public List<Produto> Produtos { get; set; }
        public int Cpnj { get; set; }
        public Endereco Endereco { get; set; }

    }
}
