using AppCidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.DTO.Pessoas.RetornarListaPessoa
{
    public class RetornarListaPessoaResponse
    {
        public List<Pessoa> listPessoas { get; set; }
        public string msg { get; set; }
    }
}
