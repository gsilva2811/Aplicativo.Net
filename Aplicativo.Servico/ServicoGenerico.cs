using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aplicativo.DAO.Repositorios;

namespace Aplicativo.Servico
{
    public class ServicoGenerico<T> where T : class
    {
        protected RepositorioGenerico<T> Repositorio { get; set;  }

        public ServicoGenerico(bool enableLazyLoading = true)
        {
            Repositorio = new RepositorioGenerico<T>(enableLazyLoading);
        }

        public IEnumerable<T> ObterTudo()
        {
            return Repositorio.GetAll().ToList();
        }

        public T ObterPorCodigo(int codigo)
        {
            return Repositorio.Find(codigo);
        }

        public T ObterPrimeiro(Expression<Func<T, bool>> predicado)
        {
            return Repositorio.FindFirst(predicado);
        }

        public int QuantidadeTotalDeRegistros(Expression<Func<T, bool>> predicado = null)
        {
            if (predicado == null)
                return Repositorio.RowCount();

            return Repositorio.RowCount(predicado);
        }

        public void Cadastrar(T entity)
        {
            Repositorio.Add(entity);
            Salvar();
        }

        public void Editar(T entity)
        {
            Repositorio.Update(entity);
            Salvar();
        }

        public void Excluir(int entidadeId)
        {
            var entity = ObterPorCodigo(entidadeId);
            Repositorio.Remove(entity);
            Salvar();
        }

        public void Excluir(T entidade)
        {
            Repositorio.Remove(entidade);
            Salvar();
        }

        private void Salvar()
        {
            Repositorio.SaveChanges();
            Repositorio.Dispose();
        }
    }
}
