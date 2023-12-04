using eclipseworks_teste.Context;
using Microsoft.EntityFrameworkCore;

namespace eclipseworks_teste.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        int Count(TEntity entEntity);
        void Dispose();
        IList<TEntity> GetAll();
        IList<TEntity> GetAll(int amt);
        TEntity GetById(long id);
        TEntity GetById(string id);
        void Remove(TEntity entEntity);
        void RemoveById(long id);
        void Save(TEntity entEntity);
        void Update(TEntity entEntity);
    }

    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly EclipseContext Db;

        public BaseRepository(EclipseContext ctx)
        {
            Db = ctx;
        }

        public int Count(TEntity entEntity)
        {
            return Db.Set<TEntity>().Count();
        }

        public IList<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IList<TEntity> GetAll(int amt)
        {
            return Db.Set<TEntity>().Take(amt).ToList();
        }


        public virtual TEntity GetById(long id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetById(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void RemoveById(long id)
        {
            var entity = Db.Set<TEntity>().Find(id);
            Db.Set<TEntity>().Remove(entity);
            Db.SaveChanges();
        }

        public void Remove(TEntity entEntity)
        {
            Db.Set<TEntity>().Remove(entEntity);
            Db.SaveChanges();
        }

        public void Save(TEntity entEntity)
        {
            Db.Set<TEntity>().Add(entEntity);
            Db.SaveChanges();
        }


        public void Update(TEntity entEntity)
        {
            Db.Entry(entEntity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
