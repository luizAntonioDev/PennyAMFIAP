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
            _context.Acessos.Update(acesso);
        }

        public void Cadastrar(Acesso acesso)
        {
            _context.Acessos.Add(acesso);
        }

        public void Deletar(int id)
        {
            var acesso = _context.Acessos.Find(id);
            _context.Acessos.Remove(acesso);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

    
