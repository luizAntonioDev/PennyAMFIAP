using Penny.NetCore.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class AcessoController : Controller
    {

        private IAcessoRepository _acessoRepository;

        public AcessoController(IAcessoRepository acessoRepository)
        {
            _acessoRepository = acessoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}