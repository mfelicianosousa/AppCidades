using AppCidades.Bordas.Adapter;
using AppCidades.Bordas.Repositorios;
using AppCidades.DTO.Pessoas.AdicionarPessoa;
using AppCidades.Entities;
using AppCidades.UseCase.Pessoa;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppCidades.Builder;
using Xunit;

namespace TestAppCidades.UseCase
{

    
    public class AdicionarPessoaUseCaseTest
    {
        private readonly Mock<IRepositorioPessoas> _repositorioPessoas;
        private readonly Mock<IAdicionarPessoaAdapter> _adicionarPessoaAdapter;
        private readonly AdicionarPessoaUseCase _useCaseAdicionarPessoa;

        public AdicionarPessoaUseCaseTest()
        {
            _repositorioPessoas = new Mock<IRepositorioPessoas>();
            _adicionarPessoaAdapter = new Mock<IAdicionarPessoaAdapter>();
            _useCaseAdicionarPessoa = new AdicionarPessoaUseCase(
                _repositorioPessoas.Object ,
                _adicionarPessoaAdapter.Object
            );
        }

        [Fact]
        public void Pessoa_AdicionarPessoa_QuandoRetornarSucesso()
        {
            // Arrange - Criar as variáveis
            var request = new AdicionarPessoaRequestBuilder().Build();
            var response = new AdicionarPessoaResponse();
            var pessoa = new Pessoa();
            pessoa.id = 1L;
            response.id = pessoa.id;
            response.msg = "Adicionado com sucesso";
            

            // Aqui retorna o caminho feliz
             _repositorioPessoas.Setup(repositorio => repositorio.Add(pessoa)).Returns(pessoa.id);
            _adicionarPessoaAdapter.Setup(adapter => adapter.converterRequestParaPessoa(request)).Returns(pessoa);
            // Aqui vai retornar uma exception, que é o caminho que vai gerar o erro
            //_repositorioPessoas.Setup(repositorio => repositorio.Add(pessoa)).Throws(new System.Exception());

            // Act - Chamar as funções
            var result = _useCaseAdicionarPessoa.Executar(request);


            // Assert - As regras dos teste que vamos utilizar
            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Pessoa_AdicionarPessoa_QuandoNomeMenorVinte()
        {
            // Arrange - Criar as variáveis
            var request = new AdicionarPessoaRequestBuilder().withNameLength(10).Build();
            var response = new AdicionarPessoaResponse();
            
            response.msg = "Erro ao adicionar uma Pessoa";
           
            // Act - Chamar as funções
            var result = _useCaseAdicionarPessoa.Executar(request);


            // Assert - As regras dos teste que vamos utilizar
            response.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void Pessoa_AdicionarPessoa_QuandoRepositorioExcecao()
        {
            // Arrange - Criar as variáveis
            var request = new AdicionarPessoaRequestBuilder().Build();
            var response = new AdicionarPessoaResponse();
            var pessoa = new Pessoa();
            pessoa.id = 1L;
            response.msg = "Erro ao adicionar Pessoa";

            _adicionarPessoaAdapter.Setup(adapter => adapter.converterRequestParaPessoa(request)).Returns(pessoa);
            _repositorioPessoas.Setup(repositorio => repositorio.Add(pessoa)).Throws(new Exception());
             
            // Act - Chamar as funções
            var result = _useCaseAdicionarPessoa.Executar(request);


            // Assert - As regras dos teste que vamos utilizar
            response.Should().BeEquivalentTo(result);
        }
    }
}
