﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Penny.NetCore.Api.Controllers
{
    public class ContaBancariaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}