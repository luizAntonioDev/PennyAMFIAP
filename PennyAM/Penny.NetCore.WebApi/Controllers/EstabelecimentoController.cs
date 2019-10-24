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
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;
        public EstabelecimentoController(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        [HttpPost]
        [Route("Cadastrar/{UsuarioId}")]
        public IActionResult Cadastrar([FromBody] EstabelecimentoRequest request, [FromRoute]int UsuarioId)
        {
            try
            {
                Validacoes.ValidarEstabelecimento(request);

                var existeEstabelecimento = _estabelecimentoRepository.BuscarPor(x => x.Cnpj == request.Cnpj).FirstOrDefault();

                if (existeEstabelecimento != null)
                {
                    return BadRequest("Estabelecimento já cadastrado");
                }

                var estabelecimento = _estabelecimentoRepository.Cadastrar(new Estabelecimento()
                {
                    Cnpj = request.Cnpj,
                    Usuario = new Usuario()
                    {
                        UsuarioId = UsuarioId
                    },
                    Endereco = request.Endereco,
                    DataCadastro = DateTime.Now,
                    Descricao = request.Descricao
                });

                return Ok("Estabelecimento " + estabelecimento.Id + "criado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpPost]
        [Route("Atualizar/{Cnpj}")]
        public IActionResult Atualizar([FromBody] EstabelecimentoRequest request, [FromRoute]string Cnpj)
        {
            try
            {
                Validacoes.ValidarEstabelecimento(request);

                var existeEstabelecimento = _estabelecimentoRepository.BuscarPor(x => x.Cnpj == Cnpj).FirstOrDefault();

                if (existeEstabelecimento == null)
                {
                    return BadRequest("Estabelecimento não está cadastrado");
                }

                existeEstabelecimento.Endereco = request.Endereco;
                existeEstabelecimento.Descricao = request.Descricao;

                existeEstabelecimento = _estabelecimentoRepository.Atualizar(existeEstabelecimento);

                return Ok("Estabelecimento " + existeEstabelecimento.Id + " atualizado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

        [HttpGet]
        [Route("{EstabelecimentoId}")]
        public IActionResult Get([FromRoute] int EstabelecimentoId)
        {
            try
            {

                var estabelecimento = _estabelecimentoRepository.BuscarPorId(EstabelecimentoId);

                if (estabelecimento == null)
                {
                    return BadRequest("Estabelecimento não cadastrado");
                }

                return Ok(estabelecimento);
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

                var estabelecimento = _estabelecimentoRepository.Listar();

                if (estabelecimento == null)
                {
                    return BadRequest("Produto não cadastrado");
                }

                return Ok(estabelecimento);
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

    }
}