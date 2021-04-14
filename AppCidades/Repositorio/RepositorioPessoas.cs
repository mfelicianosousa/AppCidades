using AppCidades.Bordas.Repositorios;
using AppCidades.Context;
using AppCidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCidades.Repositorio
{
    public class RepositorioPessoas : IRepositorioPessoas
    {
        private readonly LocalDbContext _local;

        public RepositorioPessoas(LocalDbContext local)
        {
            _local = local;
        }

        public List<Pessoa> AllList()
        {
            return _local.pessoa.ToList();
        }

        public long Add(Pessoa request)
        {
            _local.pessoa.Add(request);
            _local.SaveChanges();
            return request.id;
        }

        public void Remove(long id)
        {
            var obj = _local.pessoa.Where(p => p.id == id).FirstOrDefault();
            if (obj == null)
            {
                throw new System.Exception("Pessoa não existe");
            }
            _local.pessoa.Remove(obj);
            _local.SaveChanges();
        }

        public Pessoa FindById(long id)
        {
            var obj = _local.pessoa.SingleOrDefault(p => p.id.Equals(id));
            // var result = _local.pessoa.Where(p => p.id == id).FirstOrDefault();
            if (
                obj != null)
           {
                return obj;
            }
            else
            {
                 throw new System.Exception("Pessoa não existe");
            }
            

        }

        public Pessoa Update(Pessoa pessoa)
        {
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

       
    }
}
