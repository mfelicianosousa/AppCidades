using AppCidades.DTO.Pessoa.AdicionarPessoa;
using AppCidades.Entities;
using AppCidades.Services;
using AppCidades.UseCase.Pessoa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppCidades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaService _pessoa;
        private readonly IAdicionarPessoaUseCase _adicionarPessoaUseCase;

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
        public IActionResult Adicionar([FromBody] AdicionarPessoaRequest pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            //return Ok(_pessoa.AdicionarPessoa(pessoa));
            return Ok(_adicionarPessoaUseCase.Executar(pessoa));
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
