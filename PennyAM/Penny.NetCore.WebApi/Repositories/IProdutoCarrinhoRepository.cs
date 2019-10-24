
using Penny.NetCore.WebApi.Models;
using System;
using System.Linq.Expressions;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface IProdutoCarrinhoRepository
    {
        void Cadastrar(ProdutoCarrinho produto);
        void Deletar(ProdutoCarrinho produto);
        ProdutoCarrinho BuscarPor(Expression<Func<ProdutoCarrinho, bool>> filtro);
    }
}