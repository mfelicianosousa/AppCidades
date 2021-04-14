using AppCidades.Entities;
using System.Collections.Generic;

namespace AppCidades.Bordas.Repositorios
{
    
    public interface IRepositorioPessoas
    {
        public List<Pessoa> AllList();
        public long Add(Pessoa request);
        public Pessoa Update(Pessoa pessoa);
        public void Remove(long id);
        public Pessoa FindById(long id);

    }


}
