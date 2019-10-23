using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface IAcessoRepository
    {
        Acesso Cadastrar(Acesso acesso);
        Acesso Atualizar(Acesso acesso);
        void Deletar(Acesso acesso);
        Acesso Login(string login, string senha);
        Acesso BuscarPorLogin(string login);
        void Salvar();
    }
}
