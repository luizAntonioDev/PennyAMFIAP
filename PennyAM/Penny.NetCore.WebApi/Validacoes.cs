using Penny.NetCore.WebApi.Models;
using Penny.NetCore.WebApi.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Penny.NetCore.WebApi
{
    public static class Validacoes
    {

        public static void ValidarAcesso(Acesso value)
        {
            if (string.IsNullOrEmpty(value.Login))
            {
                throw new Exception("Informe o Login");
            }

            if (string.IsNullOrEmpty(value.Senha))
            {
                throw new Exception("Informe a Senha");
            }
        }

        public static void ValidarEstabelecimento(EstabelecimentoRequest value)
        {
            if (string.IsNullOrEmpty(value.Cnpj))
            {
                throw new Exception("Informe o Cnpj");
            }

            if (string.IsNullOrEmpty(value.Descricao))
            {
                throw new Exception("Informe a descrição");
            }

            if (value.Endereco == null)
            {
                throw new Exception("Informe o Endereço");
            }
            else
            {
                ValidarEndereco(value.Endereco);
            }
        }

        public static void ValidarProduto(ProdutoRequest value)
        {
            if (string.IsNullOrEmpty(value.Nome))
            {
                throw new Exception("Informe o nome do produto");
            }

            if (string.IsNullOrEmpty(value.CodigoBarra))
            {
                throw new Exception("Informe o Codigo de Barra");
            }


            if (string.IsNullOrEmpty(value.Descricao))
            {
                throw new Exception("Informe a descrição");
            }
        }

        public static void ValidarCadastro(CadastroUsuarioRequest value)
        {

            if (value.Cliente == null)
            {
                throw new Exception("Informe os dados do Cliente");
            }

            if (string.IsNullOrEmpty(value.Cliente.Nome))
            {
                throw new Exception("Informe o nome");
            }

            if (string.IsNullOrEmpty(value.Cliente.Documento))
            {
                throw new Exception("Informe o Cpf");
            }


            if (value.Cliente.Endereco != null)
            {
                ValidarEndereco(value.Cliente.Endereco);
            }
        }
        public static void ValidarEndereco(Endereco value)
        {
            if (string.IsNullOrEmpty(value.Logradouro))
            {
                throw new Exception("Informe o Logradouro");
            }

            if (string.IsNullOrEmpty(value.Cidade))
            {
                throw new Exception("Informe a Cidade");
            }

            if (string.IsNullOrEmpty(value.Estado))
            {
                throw new Exception("Informe o Estado");
            }

            if (string.IsNullOrEmpty(value.Cep))
            {
                throw new Exception("Informe o Cep");
            }

            if (string.IsNullOrEmpty(value.Bairro))
            {
                throw new Exception("Informe o Bairro");
            }

        }
    }
}
