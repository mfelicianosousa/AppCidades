using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.DTO.Pessoas.AtualizarPessoa
{
    public class AtualizarPessoaRequest
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
    }
}
