using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models.Request
{
    public class EstabelecimentoRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
