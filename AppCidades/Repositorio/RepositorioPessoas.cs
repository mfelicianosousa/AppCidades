using AppCidades.Bordas.Repositorios;
using AppCidades.Context;
using AppCidades.DTO.Pessoa.AdicionarPessoa;
using AppCidades.Entities;
using System;

namespace AppCidades.Repositorio
{
    public class RepositorioPessoas : IRepositorioPessoas
    {
        private readonly LocalDbContext _local;

        public RepositorioPessoas(LocalDbContext local)
        {
            _local = local;
        }

        public void Add(Pessoa request)
        {
            _local.pessoa.Add(request);
            _local.SaveChanges();
        }
    }
}
