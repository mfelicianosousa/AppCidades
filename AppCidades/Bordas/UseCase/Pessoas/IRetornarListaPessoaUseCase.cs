using AppCidades.DTO.Pessoas.RetornarListaPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.UseCase.Pessoa
{
    public interface IRetornarListaPessoaUseCase
    {
        RetornarListaPessoaResponse Executar(RetornarListaPessoaRequest request);
    }
}
