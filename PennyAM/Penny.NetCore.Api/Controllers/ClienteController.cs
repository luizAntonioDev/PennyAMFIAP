using Penny.NetCore.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;
        private ICarrinhoCompraRepository _carrinhoCompraRepository;

        public ClienteController(IClienteRepository clienteRepository, 
            ICarrinhoCompraRepository carrinhoCompraRepository)
        {
            _clienteRepository = clienteRepository;
            _carrinhoCompraRepository = carrinhoCompraRepository;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}