using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private PennyContext _context;

        public CarrinhoCompraRepository(PennyContext context)
        {
            _context = context;
        }

        public CarrinhoCompra Cadastrar(CarrinhoCompra carrinhoCompra)
        {
            _context.Entry(carrinhoCompra).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return carrinhoCompra;
        }

        public void Deletar(CarrinhoCompra carrinhoCompra)
        {
            _context.Entry(carrinhoCompra).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeletarPorClienteId(List<CarrinhoCompra> carrinhoCompra)
        {

            _context.Entry(carrinhoCompra).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }

        public CarrinhoCompra ObterPorId(int carrinhoId)
        {
            return _context.CarrinhoCompras.Where(x => x.CarrinhoCompraId == carrinhoId).FirstOrDefault();
        }
    }
}
