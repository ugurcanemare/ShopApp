using ShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        List<Product> GetHomePageProducts();
        Product GetProductDetailsByUrl(string producturl);
        void CreateProductWithCategories(Product product, int[] selectedCategories);
        List<Product> GetAllUndeletedProducts();
        Product GetProductWithCategories(int id);
        void UpdateProductWithCategories(Product product,int[] selectedCategories);
    }
}
