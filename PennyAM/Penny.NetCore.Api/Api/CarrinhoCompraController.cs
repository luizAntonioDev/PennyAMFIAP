using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Penny.NetCore.Api.Models;
using Penny.NetCore.Api.Repositories;

namespace Penny.NetCore.Api.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoCompraController : ControllerBase
    {
        private ICarrinhoCompraRepository _rep;


        public CarrinhoCompraController(ICarrinhoCompraRepository carrinhoCompraRepository) {

            _rep = carrinhoCompraRepository;

        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]CarrinhoCompra model)
        {

            _rep.Cadastrar(model);
            _rep.Salvar();
            return Created(); //201

        }

        //[HttpPost]
        //public IActionResult Incluir([FromBody] LivroUpload model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var livro = model.ToLivro();
        //        _repo.Incluir(livro);
        //        var uri = Url.Action("Recuperar", new { id = livro.Id });
        //        return Created(uri, livro); //201
        //    }
        //    return BadRequest();
        //}


    }
}