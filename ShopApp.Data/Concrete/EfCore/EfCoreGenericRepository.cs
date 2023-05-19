using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, new()
    {
        ShopAppContext context = new ShopAppContext();
        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
            //context.Entry(entity).State = EntityState.Modified;
        }
    }
}