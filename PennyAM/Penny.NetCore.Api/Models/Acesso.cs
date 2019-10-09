using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Models
{
    public class Acesso
    {
        public int AcessoId { get; set; }
        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public Usuario usuario { get; set; }

        public TipoUsuario Tipo { get; set; }

    }
}
