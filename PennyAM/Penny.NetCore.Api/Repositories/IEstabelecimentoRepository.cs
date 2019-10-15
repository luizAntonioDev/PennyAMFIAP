using Penny.NetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.Api.Repositories
{
    public interface IEstabelecimentoRepository
    {
        void Cadastrar(Estabelecimento estabelecimento);
        void Atualizar(Estabelecimento estabelecimento);
        void Deletar(int id);
        Estabelecimento BuscarPorId(int id);
        IList<Estabelecimento> Listar();
        IList<Estabelecimento> BuscarPor(
                Expression<Func<Estabelecimento,bool>>filtro);
        void Salvar();


    }
}
