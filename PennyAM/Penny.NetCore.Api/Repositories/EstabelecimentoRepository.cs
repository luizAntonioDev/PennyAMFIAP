using Penny.NetCore.Api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private PennyContext _context;

        public EstabelecimentoRepository(PennyContext context)
        {
            _context = context;
        }
    }
}
