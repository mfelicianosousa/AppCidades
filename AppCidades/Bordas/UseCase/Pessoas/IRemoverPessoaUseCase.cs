
using AppCidades.DTO.Pessoas.RemoverPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.UseCase.Pessoa
{
    public interface IRemoverPessoaUseCase
    {
        RemoverPessoaResponse Executar(RemoverPessoaRequest request);
    }
}
