using Penny.NetCore.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private ICarrinhoCompraRepository _carrinhoCompraRepository;
        private IClienteRepository _clienteRepository;

        public CarrinhoCompraController(ICarrinhoCompraRepository carrinhoCompraRepository,
            IClienteRepository clienteRepository)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}