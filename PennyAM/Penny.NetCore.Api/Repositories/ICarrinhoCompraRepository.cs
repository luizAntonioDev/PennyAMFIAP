using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public interface ICarrinhoCompraRepository
    {

        void Cadastrar(CarrinhoCompra carrinhoCompra);

        void Salvar();

    }
}
