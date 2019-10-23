using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class AcessoRepository : IAcessoRepository
    {
        private PennyContext _context;

        public AcessoRepository(PennyContext context)
        {
            _context = context;
        }

        public Acesso Atualizar(Acesso acesso)
        {
            _context.Entry(acesso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return acesso;
        }

        public Acesso BuscarPorLogin(string login)
        {
            return _context.Acessos.Where(x => x.Login == login).FirstOrDefault();
        }

        public Acesso Cadastrar(Acesso acesso)
        {
            _context.Entry(acesso).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return acesso;
        }

        public void Deletar(Acesso acesso)
        {
            _context.Entry(acesso).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

        }

        public Acesso Login(string login, string senha)
        {
            return _context.Acessos.Where(x => x.Login == login && x.Senha == senha).FirstOrDefault();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }
    }
}


