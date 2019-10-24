using Microsoft.AspNetCore.Mvc;
using Penny.NetCore.WebApi.Models;
using Penny.NetCore.WebApi.Models.Request;
using Penny.NetCore.WebApi.Repositories;
using System;
using System.Linq;

namespace Penny.NetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] ProdutoRequest request)
        {
            try
            {
                Validacoes.ValidarProduto(request);

                var existeProduto = _produtoRepository.BuscarPor(x => x.Nome == request.Nome).FirstOrDefault();

                if (existeProduto != null)
                {
                    return BadRequest("Produto já cadastrado");
                }

                var produto = _produtoRepository.Cadastrar(new Produto()
                {
                    Nome = request.Nome,
                    CodigoBarra = request.CodigoBarra,
                    EstabelecimentoId = request.EstabelecimentoId,
                    Descricao = request.Descricao
                });

                return Ok("Produto " + produto.ProdutoId + "criado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar([FromBody] ProdutoRequest request)
        {
            try
            {
                Validacoes.ValidarProduto(request);

                var existeProduto = _produtoRepository.BuscarPorId(request.ProdutoId);

                if (existeProduto == null)
                {
                    return BadRequest("Produto não cadastrado");
                }


                existeProduto.Nome = request.Nome;
                existeProduto.CodigoBarra = request.CodigoBarra;
                existeProduto.EstabelecimentoId = request.EstabelecimentoId;
                existeProduto.Descricao = request.Descricao;

                var produto = _produtoRepository.Atualizar(existeProduto);

                return Ok("Produto " + produto.ProdutoId + "atualizado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpGet]
        [Route("{ProdutoId}")]
        public IActionResult Get([FromRoute] int ProdutoId)
        {
            try
            {

                var produto = _produtoRepository.BuscarPorId(ProdutoId);

                if (produto == null)
                {
                    return BadRequest("Produto não cadastrado");
                }

                return Ok(produto);
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            try
            {

                var produto = _produtoRepository.Listar();

                if (produto == null)
                {
                    return BadRequest("Produto não cadastrado");
                }

                return Ok(produto);
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }
    }
}