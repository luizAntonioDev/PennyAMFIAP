using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Penny.NetCore.WebApi.Models;
using Penny.NetCore.WebApi.Models.Request;
using Penny.NetCore.WebApi.Repositories;

namespace Penny.NetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IAcessoRepository _acessoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteController(IAcessoRepository acessoRepository, IUsuarioRepository usuarioRepository, IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository)
        {
            _acessoRepository = acessoRepository;
            _usuarioRepository = usuarioRepository;
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            try
            {
                var clientes = _clienteRepository.Listar();
                return Ok(clientes);
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }



        [HttpGet]
        [Route("{UsuarioId}")]
        public IActionResult BuscarPorId(int UsuarioId)
        {
            try
            {
                var cliente = _clienteRepository.BuscarPorId(UsuarioId);
                return Ok(cliente);
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] CadastroUsuarioRequest request)
        {
            try
            {
                Validacoes.ValidarCadastro(request);

                var existeLogin = _acessoRepository.BuscarPorLogin(request.Login);

                if (existeLogin != null)
                {
                    return BadRequest("Login já Cadastrado");
                }
                var acesso = _acessoRepository.Atualizar(new Acesso()
                {
                    Login = request.Login,
                    Senha = request.Senha
                });

                var cliente = _clienteRepository.BuscarPorId(request.Cliente.ClienteId);
                if (cliente == null)
                {
                    return BadRequest("Cliente não Cadastrado");
                }

                cliente.Usuario.Nome = request.Cliente.Nome;
                cliente.DataNascimento = request.Cliente.DataNascimento;
                cliente.CashDisponivel = request.Cliente.CashDisponivel;
                cliente.Usuario.Foto = request.Cliente.Foto;

                if (request.Cliente.Endereco != null)
                {
                    cliente.Endereco = request.Cliente.Endereco;
                }

                cliente = _clienteRepository.Atualizar(cliente);

                return Ok("Cliente " + cliente.ClienteId + "atualizado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpDelete]
        [Route("{ClienteId}")]
        public IActionResult Deletar([FromRoute]int ClienteId)
        {
            try
            {
                var cliente = _clienteRepository.BuscarPorId(ClienteId);
                if (cliente == null)
                {
                    return BadRequest("Cliente não encontrado");
                }

                _acessoRepository.Deletar(cliente.Usuario.Acesso);

                return Ok("Cliente deletado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] CadastroUsuarioRequest request)
        {
            try
            {
                Validacoes.ValidarCadastro(request);

                var existeLogin = _acessoRepository.BuscarPorLogin(request.Login);

                if (existeLogin != null)
                {
                    return BadRequest("Cliente já  Cadastrado");
                }

                var cliente = _clienteRepository.BuscarPorId(request.Cliente.ClienteId);
                if (cliente != null)
                {
                    return BadRequest("Cliente já  Cadastrado com esse Id");
                }

                var acesso = _acessoRepository.Cadastrar(new Acesso()
                {

                    Login = request.Login,
                    Senha = request.Senha
                });

                var usuario = _usuarioRepository.Cadastrar(new Usuario()
                {
                    AcessoId = acesso.AcessoId,
                    Nome = request.Cliente.Nome,
                    Foto = request.Cliente.Foto
                });


                cliente = _clienteRepository.Cadastrar(new Cliente()
                {
                    Usuario = usuario,
                    Documento = request.Cliente.Documento,
                    CashDisponivel = request.Cliente.CashDisponivel,
                    DataNascimento = request.Cliente.DataNascimento
                });

                if (request.Cliente.Endereco != null)
                {
                    _enderecoRepository.Cadastrar(new Endereco()
                    {
                        Bairro = request.Cliente.Endereco.Bairro,
                        Logradouro = request.Cliente.Endereco.Logradouro,
                        Cidade = request.Cliente.Endereco.Cidade,
                        Estado = request.Cliente.Endereco.Estado,
                        Cep = request.Cliente.Endereco.Cep,
                        Numero = request.Cliente.Endereco.Numero
                    });
                }

                return Ok("Cliente " + cliente.ClienteId + " cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }
    }
}