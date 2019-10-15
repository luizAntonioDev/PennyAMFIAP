using Penny.NetCore.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class EnderecoController : Controller
    {

        private IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository) 
        {
            _enderecoRepository = enderecoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}