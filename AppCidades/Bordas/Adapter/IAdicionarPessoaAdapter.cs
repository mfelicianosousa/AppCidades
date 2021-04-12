using AppCidades.DTO.Pessoa.AdicionarPessoa;
using AppCidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.Bordas.Adapter
{
    interface IAdicionarPessoaAdapter
    {
        public Pessoa converterRequestParaPessoa(AdicionarPessoaRequest request);
    }
}
