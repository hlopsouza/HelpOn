using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Persistencia.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private BancoContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(BancoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Atualizar(T entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<T> BuscarPor(Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro).ToList();
        }
        public T BuscarLogin(Expression<Func<T, bool>> filtro)
        {
            ICollection<T> Login = _dbSet.Where(filtro).ToList();
            if (Login.Count != 0)
            {
                return Login.First();
            } else {
                return null; 
                    }
        }
        public T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
        }

        public ICollection<T> Listar()
        {
            return _dbSet.ToList();
        }

        public void Remover(int id)
        {
            var entidade = BuscarPorId(id);
            _dbSet.Remove(entidade);
        }
    }
}
