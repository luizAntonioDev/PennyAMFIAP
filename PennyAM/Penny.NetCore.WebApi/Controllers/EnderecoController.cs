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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpPost]
        [Route("Atualizar/{Id}")]
        public IActionResult Atualizar([FromBody] Endereco request, [FromRoute] int Id)
        {
            try
            {
                Validacoes.ValidarEndereco(request);

                var existeEndereco = _enderecoRepository.BuscarPorId(Id);

                if (existeEndereco == null)
                {
                    return BadRequest("Endreco não Cadastrado");
                }
                existeEndereco.Bairro = request.Bairro;
                existeEndereco.Cep = request.Cep;
                existeEndereco.Cidade = request.Cidade;
                existeEndereco.Estado = request.Estado;
                existeEndereco.Logradouro = request.Logradouro;
                existeEndereco.Numero = request.Numero;

                _enderecoRepository.Atualizar(existeEndereco);

                return Ok("Endereço " + Id + "atualizado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest("Error: " + e.Message);
            }
        }

    }
}