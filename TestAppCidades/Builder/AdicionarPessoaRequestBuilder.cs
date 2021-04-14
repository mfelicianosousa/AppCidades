using AppCidades.DTO.Pessoas.AdicionarPessoa;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppCidades.Builder
{
    public class AdicionarPessoaRequestBuilder
    {
        // Gera dados aleatórios
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly AdicionarPessoaRequest _adicionarPessoa; 

        public AdicionarPessoaRequestBuilder()
        {
            _adicionarPessoa = new AdicionarPessoaRequest();
            _adicionarPessoa.nome = _faker.Random.String(40);
            _adicionarPessoa.sexo = _faker.Person.Gender.ToString();
            _adicionarPessoa.email = _faker.Person.Email.ToLower();

        }

        public AdicionarPessoaRequestBuilder withNameLength(int tamanho)
        {
            _adicionarPessoa.nome = _faker.Random.String(tamanho) ;
            return this;
        }

        public AdicionarPessoaRequest Build()
        {
            return _adicionarPessoa;
        }
    }
}
