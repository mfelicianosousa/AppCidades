using AppCidades.DTO.Pessoa.AdicionarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.UseCase.Pessoa
{
    public interface IAdicionarPessoaUseCase
    {
        AdicionarPessoaResponse Executar(AdicionarPessoaRequest request);
    }
}
