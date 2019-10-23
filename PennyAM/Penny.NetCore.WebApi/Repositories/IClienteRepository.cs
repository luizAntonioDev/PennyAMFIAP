using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface IClienteRepository
    {
        Cliente Cadastrar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Deletar(Cliente cliente);
        Cliente BuscarPorId(int id);
        IList<Cliente> Listar();
        IList<Cliente> BuscarPor(
                Expression<Func<Cliente,bool>>filtro);
        void Salvar();
    }
}
