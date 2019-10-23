using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private PennyContext _context;

        public ProdutoRepository(PennyContext context)
        {
            _context = context;
        }
        public IList<Produto> BuscarPor(Expression<Func<Produto, bool>> filtro)
        {
            return _context.Produtos.Where(filtro).ToList();
        }

        public Produto BuscarPorId(int id)
        {
            return _context.Produtos.Find(id);
        }


        public void Deletar(int id)
        {
            var produto = _context.Produtos.Find(id);
            _context.Produtos.Remove(produto);
        }

        public void Deletar(Produto produto)
        {
            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }

        public IList<Produto> Listar()
        {
            return _context.Produtos.ToList();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }

        public Produto Atualizar(Produto Produto)
        {
            _context.Entry(Produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Produto;
        }

        public Produto Cadastrar(Produto Produto)
        {
            _context.Entry(Produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return Produto;
        }
    }
}
