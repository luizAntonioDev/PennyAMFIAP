using Penny.NetCore.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class CompraController : Controller
    {   
        private ICompraRepository _compraRepository;
        private IProdutoRepository _produtoRepository;
        private IEstabelecimentoRepository _estabelecimentoRepository;
        private ICarrinhoCompraRepository _carrinhoCompraRepository;

        public CompraController(IProdutoRepository produtoRepository, 
            IEstabelecimentoRepository estabelecimentoRepository,
            ICarrinhoCompraRepository carrinhoCompraRepository, ICompraRepository compraRepository )
        {
            _produtoRepository = produtoRepository;
            _estabelecimentoRepository = estabelecimentoRepository;
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _compraRepository = compraRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}