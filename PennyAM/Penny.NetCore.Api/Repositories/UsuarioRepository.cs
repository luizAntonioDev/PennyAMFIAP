using Penny.NetCore.Api.Context;
using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private PennyContext _context;

        public UsuarioRepository(PennyContext context)
        {
            _context = context;
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> BuscarPor(Expression<Func<Usuario, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }
    }
}
