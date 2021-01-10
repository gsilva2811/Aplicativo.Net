using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using Aplicativo.DAO.Contexto;

namespace Aplicativo.DAO.Repositorios
{
    public class RepositorioGenerico<T> : IDisposable, IRepositorioGenerico<T> where T : class
    {
        protected DBEntidades ctx;

        public RepositorioGenerico(bool lazyLoadingEnabled = true)
        {
            ctx = new DBEntidades(lazyLoadingEnabled);
        }


        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        /// <summary>
        /// Obtem dados do banco de dados filtrados de acordo com o predicado.
        /// </summary>
        /// <param name="predicate">Filtro a ser executado no banco de dados</param>
        /// <param name="navigationProperties">Propriedades (campos) eager loading</param>
        /// <returns></returns>
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            return DefineNategationProperties(navigationProperties).Where(predicate);
        }

        /// <summary>
        /// Obtem primeira entidade do banco de acordo com o filtro predicado.
        /// </summary>
        /// <param name="predicate">Filtro a ser executado no banco de dados</param>
        /// <param name="navigationProperties">Propriedades (campos) eager loading</param>
        /// <returns></returns>
        public T FindFirst(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            return DefineNategationProperties(navigationProperties).FirstOrDefault(predicate);
        }

        private IQueryable<T> DefineNategationProperties(Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetAll();
            return navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include<T, object>(navigationProperty));
        }

        public T Find(params object[] key)
        {
            return ctx.Set<T>().Find(key);
        }

        public int RowCount()
        {
            return ctx.Set<T>().Count();
        }

        public int RowCount(Expression<Func<T, bool>> predicate)
        {
            return ctx.Set<T>().Count(predicate);
        }

        public void Update(T obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public bool AlreadyModified(T obj)
        {
            return ctx.Entry(obj).State == EntityState.Modified;
        }

        public void SaveChanges()
        {
            ctx.SaveChanges();
            return;

            ///Exemplo de validação.
            try
            {
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public void Add(T obj)
        {
            ctx.Set<T>().Add(obj);
        }

        public void Remove(Func<T, bool> predicate)
        {
            ctx.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<T>().Remove(del));
        }

        public void Remove(T obj)
        {
            ctx.Set<T>().Remove(obj);
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public void Detach(T obj)
        {
            ctx.Entry(obj).State = EntityState.Detached;
        }

        public void ExecuteSqlCommand(string command)
        {
            ctx.Database.ExecuteSqlCommand(command);
        }
    }
}
