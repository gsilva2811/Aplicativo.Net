using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aplicativo.DAO.Repositorios
{
    interface IRepositorioGenerico<T> where T : class
    {
        IQueryable<T> GetAll();

        /// <summary>
        /// Obtem dados do banco de dados filtrados de acordo com o predicado.
        /// </summary>
        /// <param name="predicate">Filtro a ser executado no banco de dados</param>
        /// <param name="navigationProperties">Propriedades (campos) eager loading</param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Obtem primeira entidade do banco de acordo com o filtro predicado.
        /// </summary>
        /// <param name="predicate">Filtro a ser executado no banco de dados</param>
        /// <param name="navigationProperties">Propriedades (campos) eager loading</param>
        /// <returns></returns>
        T FindFirst(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);
        

        T Find(params object[] key);
        void Update(T obj);
        void SaveChanges();
        void Add(T obj);
        void Remove(Func<T, bool> predicate);
    }
}
