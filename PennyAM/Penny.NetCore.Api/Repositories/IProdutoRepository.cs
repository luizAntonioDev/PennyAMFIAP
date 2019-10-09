using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(int id);
        Produto BuscarPorId(int id);
        IList<Produto> Listar();
        IList<Produto> BuscarPor(
            Expression<Func<Produto, bool>> filtro);
        void Salvar();
    }
}
