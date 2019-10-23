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
    public class UsuarioController : ControllerBase
    {
        private readonly IAcessoRepository _acessoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public UsuarioController(IAcessoRepository acessoRepository, IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository)
        {
            _acessoRepository = acessoRepository;
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
        }

        [HttpPost]
        [Route("CadastrarAcesso")]
        public IActionResult CadastrarAcesso([FromBody] Acesso request)
        {
            try
            {
                Validacoes.ValidarAcesso(request);

                var existeLogin = _acessoRepository.BuscarPorLogin(request.Login);

                if (existeLogin != null)
                {
                    return BadRequest("Login já Cadastrado");
                }
                var acesso = _acessoRepository.Cadastrar(new Acesso()
                {
                    Login = request.Login,
                    Senha = request.Senha,
                    Tipo = PennyConfig.TipoUsuario.Cliente
                });


                return Ok("Acesso " + acesso.AcessoId + "cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AcessoRequest request)
        {
            try
            {
                var acesso = _acessoRepository.Login(request.Login.Trim(), request.Senha.Trim());

                if (acesso == null)
                {
                    return BadRequest("Usuário não encontrado");
                }
                else
                {
                    acesso.Senha = null;
                    return Ok(acesso);
                }
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }




    }
}