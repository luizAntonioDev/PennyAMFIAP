using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private PennyContext _context;

        public ClienteRepository(PennyContext context)
        {
            _context = context;
        }

        public IList<Cliente> BuscarPor(Expression<Func<Cliente, bool>> filtro)
        {
            return _context.Clientes.Where(filtro).ToList();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.Find(id);
        }

        public IList<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }

        public Cliente Atualizar(Cliente Cliente)
        {
            _context.Entry(Cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Cliente;
        }

        public Cliente Cadastrar(Cliente Cliente)
        {
            _context.Entry(Cliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return Cliente;
        }

        public void Deletar(Cliente Cliente)
        {
            _context.Entry(Cliente).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

        }
    }
}

