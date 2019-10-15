using Penny.NetCore.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepository _produtoRepository;
        private IEstabelecimentoRepository _estabelecimentoRepository;

        public ProdutoController(IProdutoRepository produtoRepository, 
            IEstabelecimentoRepository estabelecimentoRepository)
        {
            _produtoRepository = produtoRepository;
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}