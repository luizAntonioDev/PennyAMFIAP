using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public interface IEnderecoRepository
    {
        void Cadastrar(Endereco endereco);
        void Atualizar(Endereco endereco);
        void Deletar(int id);
        Endereco BuscarPorId(int id);
        IList<Endereco> Listar();
        IList<Endereco> BuscarPor(
            Expression<Func<Endereco, bool>> filtro);
        void Salvar();


    }
}
