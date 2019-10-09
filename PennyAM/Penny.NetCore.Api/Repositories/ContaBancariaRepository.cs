using Penny.NetCore.Api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private PennyContext _context;

        public ContaBancariaRepository(PennyContext context)
        {
            _context = context;
        }
    }
}
