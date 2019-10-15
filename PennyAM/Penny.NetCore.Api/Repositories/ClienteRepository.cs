using Penny.NetCore.Api.Context;
using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private PennyContext _context;

        public ClienteRepository(PennyContext context)
        {
            _context = context;
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public IList<Cliente> BuscarPor(Expression<Func<Cliente, bool>> filtro)
        {
            return _context.Clientes.Where(filtro).ToList();
        }

        public Cliente BuscarPorId (int id)
        {
            return _context.Clientes.Find(id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Deletar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            _context.Clientes.Remove(cliente);
        }

        public IList<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

