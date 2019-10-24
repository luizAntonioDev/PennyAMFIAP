using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Penny.NetCore.WebApi.Models;
using Penny.NetCore.WebApi.Models.Request;
using Penny.NetCore.WebApi.Repositories;

namespace Penny.NetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
        private readonly IProdutoCarrinhoRepository _produtoCarrinhoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        public CarrinhoController(ICarrinhoCompraRepository carrinhoCompraRepository, IProdutoCarrinhoRepository produtoCarrinhoRepository,
            IClienteRepository clienteRepository,
            IProdutoRepository produtoRepository)
        {
            _clienteRepository = clienteRepository;
            _carrinhoCompraRepository = carrinhoCompraRepository;
            _produtoCarrinhoRepository = produtoCarrinhoRepository;
            _produtoRepository = produtoRepository;
        }


        [HttpPost]
        [Route("Criar")]
        public IActionResult CriarCarrinho([FromBody]int ClienteId)
        {
            try
            {
                var cliente = _clienteRepository.BuscarPorId(ClienteId);

                if (cliente == null)
                {
                    return BadRequest("Cliente não encontrado");
                }
                var novoCarrinho = _carrinhoCompraRepository.Cadastrar(new Models.CarrinhoCompra()
                {
                    Ativo = true,
                    Cliente = new Models.Cliente()
                    {
                        ClienteId = ClienteId
                    },
                    DataCarrinho = DateTime.Now
                });

                return Ok(cliente);
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpPost]
        [Route("AdicionarProduto")]
        public IActionResult AdicionarProduto([FromBody]ProdutoCarrinhoRequest request)
        {
            try
            {
                var carrinho = _carrinhoCompraRepository.ObterPorId(request.CarrinhoId);

                if (carrinho == null)
                {
                    return BadRequest("Carrinho não encontrado");
                }

                var produto = _produtoRepository.BuscarPorId(request.ProdutoId);

                if (produto == null)
                {
                    return BadRequest("Produto não encontrado");
                }

                _produtoCarrinhoRepository.Cadastrar(new ProdutoCarrinho()
                {
                    CarrinhoCompra = new CarrinhoCompra()
                    {
                        CarrinhoCompraId = carrinho.CarrinhoCompraId
                    },
                    Produto = new Produto()
                    {
                        ProdutoId = produto.ProdutoId
                    }
                });

                return Ok("Produto adicionado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }


        [HttpDelete]
        [Route("RemoverProduto")]
        public IActionResult RemoverProduto([FromBody]ProdutoCarrinhoRequest request)
        {
            try
            {

                var produtoCarrinho = _produtoCarrinhoRepository.BuscarPor(x => x.Produto.ProdutoId == request.ProdutoId && x.CarrinhoCompra.CarrinhoCompraId == request.CarrinhoId);

                if (produtoCarrinho == null)
                {
                    return BadRequest("Produto não encontrado no carrinho");
                }

                _produtoCarrinhoRepository.Deletar(produtoCarrinho);

                return Ok("Produto removido com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }
    }
}