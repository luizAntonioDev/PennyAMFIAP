using Penny.NetCore.Api.Context;
using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Atualizar(Estabelecimento estabelecimento)
        {
            _context.Estabelecimentos.Update(estabelecimento);
        }

        public IList<Estabelecimento> BuscarPor(Expression<Func<Estabelecimento, bool>> filtro)
        {
            return _context.Estabelecimentos.Where(filtro).ToList();
        }

        public Estabelecimento BuscarPorId(int id)
        {
           return _context.Estabelecimentos.Find(id);
        }

        public void Cadastrar(Estabelecimento estabelecimento)
        {
             _context.Estabelecimentos.Add(estabelecimento);
        }

        public void Deletar(int id)
        {
            var estabelecimento = _context.Estabelecimentos.Find(id);
            _context.Estabelecimentos.Remove(estabelecimento);
        }

        public IList<Estabelecimento> Listar()
        {
            return _context.Estabelecimentos.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
