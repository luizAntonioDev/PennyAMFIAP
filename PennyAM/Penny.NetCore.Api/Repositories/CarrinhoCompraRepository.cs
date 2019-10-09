using Penny.NetCore.Api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private PennyContext _context;

        public CarrinhoCompraRepository(PennyContext context)
        {
            _context = context;
        }

    }
}
