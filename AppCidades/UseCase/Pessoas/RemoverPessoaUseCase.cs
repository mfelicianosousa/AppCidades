using AppCidades.Bordas.Repositorios;
using AppCidades.DTO.Pessoas.RemoverPessoa;
using AppCidades.Repositorio;
using System;

namespace AppCidades.UseCase.Pessoa
{
    public class RemoverPessoaUseCase : IRemoverPessoaUseCase
    {
        private readonly IRepositorioPessoas _repositorioPessoas;

        public RemoverPessoaUseCase( IRepositorioPessoas repositorioPessoas)
        {
            _repositorioPessoas = repositorioPessoas;
        }

        public RemoverPessoaResponse Executar(RemoverPessoaRequest request)
        {
            var response = new RemoverPessoaResponse();
            try
            {
                
                _repositorioPessoas.Remove(request.id);
                response.msg = "Removido com sucesso";
                return response;

            } catch
            {
                response.msg = "Não foi possivel remover a pessoa!";
                return response;
            }
            
        }
    }
}
