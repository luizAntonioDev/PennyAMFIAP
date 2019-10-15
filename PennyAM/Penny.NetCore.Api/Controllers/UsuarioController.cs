using Penny.NetCore.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class UsuarioController : Controller
    {

        private IUsuarioRepository _usuarioRepository;
        private IAcessoRepository _acessoRepository;
        private IEnderecoRepository _enderecoRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, 
            IAcessoRepository acessoRepository, IEnderecoRepository enderecoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _acessoRepository = acessoRepository;
            _enderecoRepository = _enderecoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}