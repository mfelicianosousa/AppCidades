
using AppCidades.Bordas.Adapter;
using AppCidades.Bordas.Repositorios;
using AppCidades.DTO.Pessoas.AdicionarPessoa;

namespace AppCidades.UseCase.Pessoa
{
    public class AdicionarPessoaUseCase : IAdicionarPessoaUseCase
    {
        private readonly IRepositorioPessoas _repositorioPessoas;
        private readonly IAdicionarPessoaAdapter _adapter;

        public AdicionarPessoaUseCase(IRepositorioPessoas repositorioPessoas,
                                      IAdicionarPessoaAdapter adapter)
        {
            _repositorioPessoas = repositorioPessoas;
            _adapter = adapter;
        }

        public AdicionarPessoaResponse Executar(AdicionarPessoaRequest request)
        {
            var response = new AdicionarPessoaResponse();
            try
            {
                if (request.nome.Length < 20)
                {
                    response.msg = "Erro ao adicionar uma Pessoa";
                    return response;
                }
              
                var pessoaAdicionar = _adapter.converterRequestParaPessoa(request);
                _repositorioPessoas.Add(pessoaAdicionar);
                response.msg = "Adicionado com sucesso";
                response.id = pessoaAdicionar.id;
                return response;

            } catch
            {
                response.msg = "Erro ao adicionar Pessoa";
                return response;
            }
            
        }
    }
}
