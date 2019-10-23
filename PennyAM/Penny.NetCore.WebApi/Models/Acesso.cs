using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Penny.NetCore.WebApi.Models.PennyConfig;

namespace Penny.NetCore.WebApi.Models
{
    public class Acesso
    {
        public int AcessoId { get; set; }
        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }


        public TipoUsuario Tipo { get; set; }
    }
}
