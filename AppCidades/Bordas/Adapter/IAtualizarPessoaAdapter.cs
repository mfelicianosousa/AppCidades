using AppCidades.DTO.Pessoas.AtualizarPessoa;
using AppCidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.Bordas.Adapter
{
    public interface IAtualizarPessoaAdapter
    {
        public Pessoa converterRequestParaPessoa(AtualizarPessoaRequest request);
    }
}
