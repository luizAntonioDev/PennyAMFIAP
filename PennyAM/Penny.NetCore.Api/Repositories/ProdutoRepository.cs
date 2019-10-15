using Penny.NetCore.Api.Context;
using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private PennyContext _context;

        public ProdutoRepository(PennyContext context)
        {
            _context = context;
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public IList<Produto> BuscarPor(Expression<Func<Produto, bool>> filtro)
        {
            return _context.Produtos.Where(filtro).ToList();
        }

        public Produto BuscarPorId(int id)
        {
            return _context.Produtos.Find(id);
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Deletar(int id)
        {
            var produto = _context.Produtos.Find(id);
            _context.Produtos.Remove(produto);
        }

        public IList<Produto> Listar()
        {
            return _context.Produtos.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
