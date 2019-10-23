using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private PennyContext _context;

        public CompraRepository(PennyContext context)
        {
            _context = context;
        }

        public void Atualizar(Compra compra)
        {
            _context.Compras.Update(compra);
        }

        public IList<Compra> BuscarPor(Expression<Func<Compra, bool>> filtro)
        {
            return _context.Compras.Where(filtro).ToList();
        }

        public Compra BuscarPorId(int id)
        {
            return _context.Compras.Find(id);
        }

        public void Deletar(int id)
        {
            var compra = _context.Compras.Find(id);
            _context.Compras.Remove(compra);
        }

        public IList<Compra> Listar()
        {
            return _context.Compras.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
