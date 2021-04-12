using AppCidades.Bordas.Adapter;
using AppCidades.DTO.Pessoa.AdicionarPessoa;
using AppCidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.Adapter
{
    public class AdicionarPessoaAdapter : IAdicionarPessoaAdapter
    {
        public Pessoa converterRequestParaPessoa(AdicionarPessoaRequest request)
        {
            var pessoa = new Pessoa();
            pessoa.nome = request.nome;
            pessoa.cpf = request.cpf;
            pessoa.sexo = request.sexo;
            pessoa.email = request.email;

            return pessoa;

        }
    }
}
