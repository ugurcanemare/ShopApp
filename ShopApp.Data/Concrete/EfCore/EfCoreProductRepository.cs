using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;
using ShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        ShopAppContext context = new ShopAppContext();

        public void CreateProductWithCategories(Product product, int[] selectedCategories)
        {
            context.Products.Add(product);
            context.SaveChanges();
            List<ProductCategory> productCategories = new List<ProductCategory>();
            foreach (int categoryId in selectedCategories)
            {
                productCategories.Add(new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = categoryId
                });
            }
            context.ProductCategories.AddRange(productCategories);
            context.SaveChanges();
        }

        public List<Product> GetAllUndeletedProducts()
        {
            return context
                .Products
                .Where(p => !p.IsDeleted)
                .ToList();  
        }

        public List<Product> GetHomePageProducts()
        {
            return context.Products.Where(p => p.IsHome && p.IsApproved && !p.IsDeleted).ToList();
        }

        public Product GetProductDetailsByUrl(string producturl)
        {
            Product resultProduct = context
                                    .Products
                                    .Where(p => p.Url == producturl)
                                    .Include(p => p.ProductCategories)
                                    .ThenInclude(pc => pc.Category)
                                    .FirstOrDefault();
            return resultProduct;
        }

        public Product GetProductWithCategories(int id)
        {
            return context
                .Products
                .Where(p=> p.Id == id)
                .Include(p=> p.ProductCategories)
                .ThenInclude(pc=> pc.Category)
                .FirstOrDefault();
        }

        public void UpdateProductWithCategories(Product updatedProduct, int[] selectedCategories)
        {
            Product product = context
                .Products
                .Include(p=>p.ProductCategories)
                .FirstOrDefault(p=>p.Id == updatedProduct.Id);
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.IsHome = updatedProduct.IsHome;
            product.IsApproved = updatedProduct.IsApproved;
            product.IsDeleted = updatedProduct.IsDeleted;
            product.UpdatedDate = DateTime.Now;
            product.Url = updatedProduct.Url;
            product.ImageUrl = updatedProduct.ImageUrl;
            product.ProductCategories = selectedCategories
                .Select(sc=> new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = sc
                }).ToList();
                context.Update(product);
                context.SaveChanges();
        }
    }
}