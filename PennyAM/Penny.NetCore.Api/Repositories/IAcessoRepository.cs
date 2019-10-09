using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public interface IAcessoRepository
    {
        void Cadastrar(Acesso acesso);
        void Atualizar(Acesso acesso);
        void Deletar(int id);
    }
}
