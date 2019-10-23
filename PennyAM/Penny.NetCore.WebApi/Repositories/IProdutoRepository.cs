using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface IProdutoRepository
    {
        Produto Cadastrar(Produto produto);
        Produto Atualizar(Produto produto);
        void Deletar(Produto produto);
        Produto BuscarPorId(int id);
        IList<Produto> Listar();
        IList<Produto> BuscarPor(
            Expression<Func<Produto, bool>> filtro);
        void Salvar();
    }
}
