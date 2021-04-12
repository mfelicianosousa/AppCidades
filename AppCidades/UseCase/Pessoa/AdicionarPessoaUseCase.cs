
using AppCidades.Bordas.Adapter;
using AppCidades.Bordas.Repositorios;
using AppCidades.DTO.Pessoa.AdicionarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
              
                var pessoaAdicionar = _adapter.converterRequestParaPessoa(request);
                _repositorioPessoas.Add(pessoaAdicionar);
                response.msg = "Adicionado com sucesso!";
                return response;
            } catch
            {
                response.msg = "Erro ao adicionar uma Pessoa!";
                return response;
            }
            
        }
    }
}
