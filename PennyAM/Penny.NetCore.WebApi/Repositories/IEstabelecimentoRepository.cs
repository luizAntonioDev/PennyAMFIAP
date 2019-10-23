using Penny.NetCore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi.Repositories
{
    public interface IEstabelecimentoRepository
    {
        Estabelecimento Cadastrar(Estabelecimento estabelecimento);
        Estabelecimento Atualizar(Estabelecimento estabelecimento);
        void Deletar(Estabelecimento estabelecimento);
        Estabelecimento BuscarPorId(int id);
        IList<Estabelecimento> Listar();
        IList<Estabelecimento> BuscarPor(
                Expression<Func<Estabelecimento,bool>>filtro);
        void Salvar();


    }
}
