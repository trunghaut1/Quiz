using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Core.Controller
{
    public static class DataHelper<Context, TEntity>
        where TEntity : class
        where Context : DbContext, new()
    {

        static Context _context = new Context();

        public static List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public static TEntity FindByPrimaryKey(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public static TEntity FindByPrimaryKey(string userid)
        {
            return _context.Set<TEntity>().Find(userid);
        }
        public static TEntity FindByPrimaryKey(string subid, string userid)
        {
            return _context.Set<TEntity>().Find(subid, userid);
        }
        public static int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }
        public static int Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();
        }
        public static void Edit(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
        public static IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);
            return query;
        }
        public static void AddOrUpdate(TEntity entity)
        {
            _context.Set<TEntity>().AddOrUpdate(entity);
            _context.SaveChanges();
        }
    }
}
