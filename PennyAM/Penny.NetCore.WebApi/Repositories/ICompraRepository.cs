using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface ICompraRepository
    {
        void Atualizar(Compra compra);
        void Deletar(int id);
        Compra BuscarPorId(int id);
        IList<Compra> Listar();
        IList<Compra> BuscarPor(
            Expression<Func<Compra,bool>>filtro);
        void Salvar();

    }
}
