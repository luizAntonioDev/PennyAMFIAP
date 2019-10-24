using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Penny.NetCore.WebApi.Models;
using Penny.NetCore.WebApi.Repositories;

namespace Penny.NetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
        public CompraController(ICarrinhoCompraRepository carrinhoCompraRepository, ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
            _carrinhoCompraRepository = carrinhoCompraRepository;
        }


        [HttpPost]
        public IActionResult BuscarPorId([FromBody] int CarrinhoId)
        {
            try
            {
                var carrinho = _carrinhoCompraRepository.ObterPorId(CarrinhoId);


                if (carrinho == null)
                {
                    return BadRequest("Carrinho não encontrado");
                }

                if (carrinho.ProdutosCarrinho.Any())
                {
                    var valorTotal = carrinho.ProdutosCarrinho.Sum(x => x.Produto.Preco);

                    var compra = _compraRepository.Cadastrar(new Compra()
                    {
                        ValorTotal = (decimal)valorTotal,
                        Unidade = new Estabelecimento()
                        {
                            Id = carrinho.ProdutosCarrinho.FirstOrDefault().Produto.EstabelecimentoId
                        },
                        DataCompra = DateTime.Now,
                        CarrinhoCompraId = CarrinhoId

                    });

                    return Ok("Compra Nº " + compra.CompraId + " realizada com sucesso");
                }
                else
                {
                    return BadRequest("O carrinho esta vazio");
                }
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }
    }
}