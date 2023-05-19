using ShopApp.Data.Abstract;
using ShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        ShopAppContext context = new ShopAppContext();
        public List<Category> GetAllUndeletedCategories()
        {
            return context
                .Categories
                .Where(c=>!c.IsDeleted)
                .ToList();
        }
    }
}