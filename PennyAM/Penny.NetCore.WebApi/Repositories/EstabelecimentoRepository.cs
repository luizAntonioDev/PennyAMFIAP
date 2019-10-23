using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private PennyContext _context;

        public EstabelecimentoRepository(PennyContext context)
        {
            _context = context;
        }

        public IList<Estabelecimento> BuscarPor(Expression<Func<Estabelecimento, bool>> filtro)
        {
            return _context.Estabelecimentos.Where(filtro).ToList();
        }

        public Estabelecimento BuscarPorId(int id)
        {
            return _context.Estabelecimentos.Find(id);
        }


        public void Deletar(Estabelecimento estabelecimento)
        {
            _context.Entry(estabelecimento).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }

        public IList<Estabelecimento> Listar()
        {
            return _context.Estabelecimentos.ToList();
        }

        public void Salvar()
        {
            throw new NotImplementedException();
        }

        Estabelecimento IEstabelecimentoRepository.Atualizar(Estabelecimento estabelecimento)
        {
            _context.Entry(estabelecimento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return estabelecimento;
        }

        Estabelecimento IEstabelecimentoRepository.Cadastrar(Estabelecimento estabelecimento)
        {
            _context.Entry(estabelecimento).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return estabelecimento;
        }
    }
}
