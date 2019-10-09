using Penny.NetCore.Api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private PennyContext _context;

        public CompraRepository(PennyContext context)
        {
            _context = context;
        }
    }
}
