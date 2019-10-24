using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Penny.NetCore.WebApi.Models.PennyConfig;

namespace Penny.NetCore.WebApi.Models.Request
{
    public class CadastroUsuarioRequest
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public TipoUsuario Tipo { get; set; }

        public ClienteRequest Cliente { get; set; }
    }
}
