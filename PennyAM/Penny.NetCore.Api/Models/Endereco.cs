using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class Endereco
    {
        public int UsuarioId { get; set; }
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public int  Numero { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Estado Estado { get; set; }

    }
}
