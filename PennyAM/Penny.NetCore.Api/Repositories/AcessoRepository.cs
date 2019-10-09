using Penny.NetCore.Api.Context;
using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class AcessoRepository : IAcessoRepository
    {
        private PennyContext _context;

        public AcessoRepository(PennyContext context)
        {
            _context = context;
        }

        public void Atualizar(Acesso acesso)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Acesso acesso)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}

    
