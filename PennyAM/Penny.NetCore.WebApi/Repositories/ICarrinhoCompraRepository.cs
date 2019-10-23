using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface ICarrinhoCompraRepository
    {

        void Cadastrar(CarrinhoCompra carrinhoCompra);

        void Salvar();

    }
}
