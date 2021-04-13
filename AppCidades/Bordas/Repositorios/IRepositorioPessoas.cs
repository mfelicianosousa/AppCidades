﻿using AppCidades.Entities;

namespace AppCidades.Bordas.Repositorios
{
    
    public interface IRepositorioPessoas
    {
        public long Add(Pessoa request);
        public void Remove(long id);
    }


}
