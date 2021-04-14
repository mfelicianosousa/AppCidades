using AppCidades.Bordas.Adapter;
using AppCidades.Bordas.Repositorios;
using AppCidades.DTO.Pessoas.AtualizarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.UseCase.Pessoa
{
    public class AtualizarPessoaUseCase : IAtualizarPessoaUseCase
    {
        private readonly IRepositorioPessoas _repositorioPessoas;
        private readonly IAtualizarPessoaAdapter _adapter;

        public AtualizarPessoaUseCase(IRepositorioPessoas repositorioPessoas,
                                      IAtualizarPessoaAdapter adapter)
        {
            _repositorioPessoas = repositorioPessoas;
            _adapter = adapter;
        }

        public AtualizarPessoaResponse Executar(AtualizarPessoaRequest request, long id)
        {
            var response = new AtualizarPessoaResponse();

            try
            {
                var repo = _repositorioPessoas.FindById(id);

                if (id <= 0 || repo == null)
                {
                    response.msg = "Erro ao atualizar pessoa";
                    return response;
                }

                var pessoa = _adapter.converterRequestParaPessoa(request);
                pessoa.id = id;
                _repositorioPessoas.Update(pessoa);
                response.msg = "Pessoa atualizado com Sucesso";
                response.id = id ;
                return response;

            }
            catch (Exception)
            {
                response.msg = "Erro ao atualizar o carro";
                response.id = id;
                return response;
            }
        }
    }
}
