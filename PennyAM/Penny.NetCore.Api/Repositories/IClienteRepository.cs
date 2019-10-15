using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Deletar(int id);
        Cliente BuscarPorId(int id);
        IList<Cliente> Listar();
        IList<Cliente> BuscarPor(
                Expression<Func<Cliente,bool>>filtro);
        void Salvar();
    }
}
