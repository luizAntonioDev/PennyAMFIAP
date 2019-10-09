using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class AcessoController : Controller
    {

        private readonly IAcessoRespository _acessoRepository;

        public AcessoController(IAcessoRespository acessoRespository)
        {
            _acessoRepository = acessoRespository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}