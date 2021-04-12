using AppCidades.Bordas.Repositorios;
using AppCidades.Context;
using AppCidades.Entities;
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

        public void Add(Pessoa request)
        {
            _local.pessoa.Add(request);
            _local.SaveChanges();
        }

        public void Remove(long id)
        {
            var obj = _local.pessoa.Where(p => p.id == id).FirstOrDefault();
            if (obj == null)
            {
                throw new System.Exception("Produto não existe");
            }
            _local.pessoa.Remove(obj);
            _local.SaveChanges();
        }
    }
}
