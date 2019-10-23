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

        public ClienteController(IAcessoRepository acessoRepository, IUsuarioRepository usuarioRepository, IClienteRepository clienteRepository)
        {
            _acessoRepository = acessoRepository;
            _usuarioRepository = usuarioRepository;
            _clienteRepository = clienteRepository;
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

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] CadastroUsuario request)
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
                    Senha = request.Senha,
                    Tipo = PennyConfig.TipoUsuario.Cliente
                });

                var cliente = _clienteRepository.BuscarPorId(request.Cliente.ClienteId);
                if (cliente == null)
                {
                    return BadRequest("Cliente não Cadastrado");
                }

                cliente.Usuario.Nome = request.Cliente.Usuario.Nome;
                cliente.Endereco = request.Cliente.Endereco;

                cliente = _clienteRepository.Atualizar(cliente);

                return Ok("Cliente " + cliente.ClienteId + "atualizado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] CadastroUsuario request)
        {
            try
            {
                Validacoes.ValidarCadastro(request);

                var existeLogin = _acessoRepository.BuscarPorLogin(request.Login);

                if (existeLogin == null)
                {
                    return BadRequest("Acesso não  Cadastrado");
                }
                var acesso = _acessoRepository.Atualizar(new Acesso()
                {
                    Login = request.Login,
                    Senha = request.Senha,
                    Tipo = PennyConfig.TipoUsuario.Cliente
                });

                var cliente = _clienteRepository.BuscarPorId(request.Cliente.ClienteId);
                if (cliente != null)
                {
                    return BadRequest("Cliente já  Cadastrado com esse Id");
                }

                cliente.Usuario.Nome = request.Cliente.Usuario.Nome;
                cliente.Endereco = request.Cliente.Endereco;

                cliente = _clienteRepository.Cadastrar(new Cliente()
                {
                    Usuario = request.Cliente.Usuario,
                    Endereco = request.Cliente.Endereco,
                    Cpf = request.Cliente.Cpf
                });

                return Ok("Cliente " + cliente.ClienteId + "cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }
    }
}