using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private PennyContext _context;

        public UsuarioRepository(PennyContext context)
        {
            _context = context;
        }

        public IList<Usuario> BuscarPor(Expression<Func<Usuario, bool>> filtro)
        {
            return _context.Usuarios.Where(filtro).ToList();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public IList<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }

        public Usuario Atualizar(Usuario usuario)
        {
            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return usuario;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return usuario;
        }

        public void Deletar(Usuario acesso)
        {
            _context.Entry(acesso).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

        }

        public IList<Cliente> ListarClientes()
        {
            return (IList<Cliente>)_context.Usuarios.ToList();
        }
    }
}
