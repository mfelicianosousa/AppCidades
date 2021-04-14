using AppCidades.DTO.Pessoas.AdicionarPessoa;
using AppCidades.DTO.Pessoas.AtualizarPessoa;
using AppCidades.DTO.Pessoas.RemoverPessoa;
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
        private readonly IAtualizarPessoaUseCase _atualizarPessoaUseCase;
        private readonly IRemoverPessoaUseCase _removerPessoaUseCase;

        public PessoaController(ILogger<PessoaController> logger,
                                IPessoaService pessoa,
                                IAdicionarPessoaUseCase adicionarPessoaUseCase,
                                IAtualizarPessoaUseCase atualizarPessoaUseCase,
                                IRemoverPessoaUseCase removerPessoaUseCase)
        {
            _logger = logger;
            _pessoa = pessoa;
            _adicionarPessoaUseCase = adicionarPessoaUseCase;
            _atualizarPessoaUseCase = atualizarPessoaUseCase;
            _removerPessoaUseCase = removerPessoaUseCase;
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
        /* Estrutura anterior 
        [HttpPost]
        public IActionResult Adicionar([FromBody] Pessoa pessoa)
        {
            // AdicionarPessoaRequest  
            if (pessoa == null)
            {
                return BadRequest();
            }
            return Ok(_pessoa.AdicionarPessoa(pessoa));
          
        }
        */
        /* Hexagonal */
        [HttpPost]
        public IActionResult Adicionar([FromBody] AdicionarPessoaRequest  pessoa)
        {
             
            if (pessoa == null)
            {
                return BadRequest();
            }
            //return Ok(_pessoa.AdicionarPessoa(pessoa));
            return Ok(_adicionarPessoaUseCase.Executar(pessoa));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] AtualizarPessoaRequest pessoa, long id )
        {
          
            if (id == 0)
            {
                return BadRequest();
            }
             return Ok(_atualizarPessoaUseCase.Executar(pessoa, id));
        }
       
        /* Estrutura Hexagonal */
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var request = new RemoverPessoaRequest();
            request.id = id; 
           return Ok(_removerPessoaUseCase.Executar(request ));
        }
    }
}
