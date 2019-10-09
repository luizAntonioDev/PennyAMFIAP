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
            throw new NotImplementedException();
        }

        public IList<Produto> BuscarPor(Expression<Func<Produto, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Produto> Listar()
        {
            throw new NotImplementedException();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }
    }
}
