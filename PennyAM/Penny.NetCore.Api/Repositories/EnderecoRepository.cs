using Penny.NetCore.Api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private PennyContext _context;

        public EnderecoRepository(PennyContext context)
        {
            _context = context;
        }
    }
}
