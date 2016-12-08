﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Persistencia.Repositories
{
   public interface IGenericRepository<T>
    {
        void Cadastrar(T entidade);
        void Atualizar(T entidade);
        void Remover(int id);
        ICollection<T> Listar();
        T BuscarPorId(int id);
        ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro);
        T BuscarLogin(Expression<Func<T, bool>> filtro);
        T BuscarPorUnitario(Expression<Func<T, bool>> filtro);
    }
}
