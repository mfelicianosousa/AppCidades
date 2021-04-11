using AppCidades.Entities;
using AppCidades.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaService _pessoa;

        public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoa)
        {
            _logger = logger;
            _pessoa = pessoa;
        }

        [HttpGet]
        public IActionResult TodasPessoas()
        {

            return Ok(_pessoa.RetonarListaPessoa());


        }

        [HttpGet("{id}")]
        public IActionResult pessoa(int id)
        {
            var pessoa = _pessoa.RetornarPessoaPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        public IActionResult Adiciona([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return Ok(_pessoa.AdicionarPessoa(pessoa));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return Ok(_pessoa.AtualizarPessoa(pessoa));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(_pessoa.DeletarPessoa(id));
        }
    }
}
