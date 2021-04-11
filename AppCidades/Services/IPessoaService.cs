using AppCidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.Services
{
    interface IPessoaService
    {
        List<Pessoa> RetonarListaPessoa();

        Pessoa RetornarPessoaPorId(int id);

        Pessoa AdicionarPessoa(Pessoa pessoa);

        Pessoa AtualizarPessoa(Pessoa pessoa);

        bool DeletarPessoa(int id);
    }
}
