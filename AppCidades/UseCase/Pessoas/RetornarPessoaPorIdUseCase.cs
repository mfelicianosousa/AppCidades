using AppCidades.Bordas.Repositorios;
using AppCidades.DTO.Pessoas.RetornarPessoaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.UseCase.Pessoa
{
    public class RetornarPessoaPorIdUseCase : IRetornarPessoaPorIdUseCase
    {
        private readonly IRepositorioPessoas _repositorioPessoas;

        public RetornarPessoaPorIdResponse Executar(RetornarPessoaPorIdRequest request)
        {
            var response = new RetornarPessoaPorIdResponse();
            try
            {
                var obj = _repositorioPessoas.FindById(request.id);
                if (request.id <= 0 || obj == null )
                {
                    response.msg = "Identificador não encontrado !!!";
                    return response;
                }

               // response = _repositorioPessoas.FindById(request.id);
                response.msg = "Pessoa encontrada com sucesso !!!";

                return response;

            }
            catch
            {
                response.msg = "Erro ao pesquisar Pessoa !!!";
                return response;
            }
        }
    }
}
