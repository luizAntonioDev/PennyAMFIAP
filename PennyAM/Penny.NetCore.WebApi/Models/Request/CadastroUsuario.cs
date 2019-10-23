using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models.Request
{
    public class CadastroUsuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public Cliente Cliente { get; set; }
    }
}
