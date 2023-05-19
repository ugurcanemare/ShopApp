using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Create(TEntity entity); 
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}