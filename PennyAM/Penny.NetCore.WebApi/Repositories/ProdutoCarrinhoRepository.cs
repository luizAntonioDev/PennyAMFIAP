using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class ProdutoCarrinhoRepository : IProdutoCarrinhoRepository
    {

        private PennyContext _context;

        public ProdutoCarrinhoRepository(PennyContext context)
        {
            _context = context;

        }

        public void Cadastrar(ProdutoCarrinho produto)
        {
            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();

        }

        public void Deletar(ProdutoCarrinho produto)
        {
            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

        }

        public ProdutoCarrinho BuscarPor(Expression<Func<ProdutoCarrinho, bool>> filtro)
        {
            return _context.ProdutoCarrinho.Where(filtro).FirstOrDefault();
        }
    }
}
