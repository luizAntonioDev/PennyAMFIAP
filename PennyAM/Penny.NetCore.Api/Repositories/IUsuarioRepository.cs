using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Deletar(int id);
        Usuario BuscarPorId(int id);
        IList<Usuario> Listar();
        IList<Usuario> BuscarPor(
            Expression<Func<Usuario, bool>> filtro);
        void Salvar();

    }
}
