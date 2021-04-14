using AppCidades.DTO.Pessoas.RetornarPessoaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.UseCase.Pessoa
{
    public interface IRetornarPessoaPorIdUseCase
    {
        RetornarPessoaPorIdResponse Executar(RetornarPessoaPorIdRequest request);
    }
}
