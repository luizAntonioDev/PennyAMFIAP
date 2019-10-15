using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Penny.NetCore.Api.Models;
using Penny.NetCore.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class EstabelecimentoController : Controller
    {

        private IEstabelecimentoRepository _estabelecimentoRepository;
        private IUsuarioRepository _usuarioRepository;
        private IProdutoRepository _produtoRepository;


        public EstabelecimentoController(IEstabelecimentoRepository estabelecimentoRepository,
            IUsuarioRepository usuarioRepository, IProdutoRepository produtoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
            _usuarioRepository = usuarioRepository;
            _produtoRepository = produtoRepository;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Cadastrar()
        {
            return View();       
        }
    

        [HttpPost]
        public IActionResult Cadastrar(Estabelecimento estabelecimento)
        {
            _estabelecimentoRepository.Cadastrar(estabelecimento);
            _estabelecimentoRepository.Salvar();
            TempData["msg"] = "Estabelecimento Cadastrado com Sucesso.";

            return RedirectToAction ("Cadastrar");
        }


    }
}