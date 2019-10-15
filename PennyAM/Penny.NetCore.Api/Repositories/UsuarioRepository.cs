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
            _context.Usuarios.Update(usuario);
        }

        public IList<Usuario> BuscarPor(Expression<Func<Usuario, bool>> filtro)
        {
            return _context.Usuarios.Where(filtro).ToList();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
           _context.Usuarios.Add(usuario);
        }

        public void Deletar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
        }

        public IList<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
