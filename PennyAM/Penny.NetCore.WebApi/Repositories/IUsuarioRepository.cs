using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Cadastrar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        void Deletar(Usuario usuario);
        Usuario BuscarPorId(int id);

        IList<Usuario> Listar();
        IList<Usuario> BuscarPor(
            Expression<Func<Usuario, bool>> filtro);
        void Salvar();

    }
}
