using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private PennyContext _context;

        public EnderecoRepository(PennyContext context)
        {
            _context = context;
        }

        public void Atualizar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public IList<Endereco> BuscarPor(Expression<Func<Endereco, bool>> filtro)
        {
           return _context.Enderecos.Where(filtro).ToList();
        }

        public Endereco BuscarPorId(int id)
        {
            return _context.Enderecos.Find(id);
        }

        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public void Deletar(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            _context.Enderecos.Remove(endereco);
        }

        public IList<Endereco> Listar()
        {
            return _context.Enderecos.ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
