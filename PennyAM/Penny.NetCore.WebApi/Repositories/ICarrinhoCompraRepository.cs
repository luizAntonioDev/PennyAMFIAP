using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface ICarrinhoCompraRepository
    {

        CarrinhoCompra Cadastrar(CarrinhoCompra carrinhoCompra);
        CarrinhoCompra ObterPorId(int carrinhoId);

        void Deletar(CarrinhoCompra carrinhoCompra);

        void DeletarPorClienteId(List<CarrinhoCompra> carrinhoCompra);



    }
}
