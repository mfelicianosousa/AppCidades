using AppCidades.Context;
using AppCidades.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades.Entities
{
    public class PessoaService : IPessoaService
    {
        private readonly LocalDbContext _local;

        public PessoaService(LocalDbContext local)
        {
            _local = local;
        }

        public List<Pessoa> RetonarListaPessoa()
        {
            return _local.pessoa.ToList();
        }

        public Pessoa AdicionarPessoa(Pessoa pessoa)
        {
            try
            {
                _local.pessoa.Add(pessoa);
                _local.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

            return pessoa;
        }

        public Pessoa AtualizarPessoa(Pessoa pessoa)
        {
            if (!Exists(pessoa.id)) return new Pessoa();

            var result = _local.pessoa.SingleOrDefault(p => p.id.Equals(pessoa.id));
            if (result != null)
            {
                try
                {
                    //_local.pessoa.Attach(pessoa);
                    //_local.Entry(pessoa).State = EntityState.Modified;
                    _local.Entry(result).CurrentValues.SetValues(pessoa);
                    _local.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return pessoa;
        }

        public bool DeletarPessoa(int id)
        {
            var result = _local.pessoa.SingleOrDefault(p => p.id.Equals(id));
            /*
            var objApagar = _local.pessoa.Where(d => d.id == id).FirstOrDefault();
            _local.pessoa.Remove(objApagar);
            _local.SaveChanges();
            */
            if (result != null)
            {
                try
                {
                    _local.pessoa.Remove(result);
                    _local.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return true;
        }

       

        public Pessoa RetornarPessoaPorId(int id)
        {
            //return _local.pessoa.Where(d => d.id == id).FirstOrDefault();
            return _local.pessoa.SingleOrDefault(p => p.id.Equals(id));
        }

        private bool Exists(long id)
        {
            return _local.pessoa.Any(p => p.id.Equals(id));
        }
    }
}
