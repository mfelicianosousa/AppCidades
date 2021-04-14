using AppCidades.Bordas.Adapter;
using AppCidades.DTO.Pessoas.AdicionarPessoa;
using AppCidades.DTO.Pessoas.AtualizarPessoa;
using AppCidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.Adapter
{
    public class AtualizarPessoaAdapter : IAtualizarPessoaAdapter
    {
        public Pessoa converterRequestParaPessoa(AtualizarPessoaRequest request)
        {
            var pessoa = new Pessoa();

            pessoa.id = request.id;
            pessoa.nome = request.nome;
            pessoa.cpf = request.cpf;
            pessoa.sexo = request.sexo;
            pessoa.email = request.email;

            return pessoa;

        }
    }
}
