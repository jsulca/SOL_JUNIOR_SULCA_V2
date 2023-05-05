using SOL_JUNIOR_SULCA.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SOL_JUNIOR_SULCA.Repositorios.Base
{
    public class BaseRepositorio<T> where T : class
    {
        protected PruebaContexto _contexto;

        public BaseRepositorio(PruebaContexto contexto)
        {
            _contexto = contexto;
        }

        public T GetOne(Expression<Func<T, bool>> condicion) => _contexto.Set<T>().Where(condicion).SingleOrDefault();
        public List<T> GetAllBy(Expression<Func<T, bool>> condicion) => _contexto.Set<T>().Where(condicion).ToList();
        public List<T> GetAll() => _contexto.Set<T>().ToList();
        public int Count() => _contexto.Set<T>().Count();
        public int CountBy(Expression<Func<T, bool>> condicion) => _contexto.Set<T>().Where(condicion).Count();

        public void Save(T entidad) => _contexto.Entry(entidad).State = System.Data.Entity.EntityState.Added;
        public void Update(T entidad) => _contexto.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
        public void Delete(T entidad) => _contexto.Entry(entidad).State = System.Data.Entity.EntityState.Deleted;

        public void Save(List<T> entidades) => entidades.ForEach(entidad => _contexto.Entry(entidad).State = System.Data.Entity.EntityState.Added);
        public void Update(List<T> entidades) => entidades.ForEach(entidad => _contexto.Entry(entidad).State = System.Data.Entity.EntityState.Modified);
        public void Delete(List<T> entidades) => entidades.ForEach(entidad => _contexto.Entry(entidad).State = System.Data.Entity.EntityState.Deleted);
    }
}
