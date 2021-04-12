﻿using AppCidades.DTO.Pessoa.AtualizarPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.UseCase.Pessoa
{
    public interface IAtualizarPessoaUseCase
    {
        AtualizarPessoaResponse Executar(AtualizarPessoaRequest request);
    }
}
