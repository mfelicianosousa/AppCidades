using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.DTO.Pessoas.AdicionarPessoa
{
    public class AdicionarPessoaRequest
    {
        public string nome { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }

    }
}
