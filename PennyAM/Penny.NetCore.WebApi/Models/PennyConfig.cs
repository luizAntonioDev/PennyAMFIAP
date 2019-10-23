using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Models
{
    public static class PennyConfig
    {
        public enum TipoUsuario
        {
            Administrador = 1,
            Estabelecimento = 2,
            Cliente = 3
        }

        public static List<string> RetornaEstados()
        {
            var estados = new List<string>(new string[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" });

            return estados;
        }
    }
}
