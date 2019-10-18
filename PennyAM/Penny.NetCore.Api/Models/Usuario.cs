using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class Usuario
    {
        public int AcessoId { get; set; }
        public Acesso Acesso { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }    
        public byte[] Foto { get; set; }


    }
}
