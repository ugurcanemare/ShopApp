using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EfCore.Config
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            /*Burada ProductId ve CategoryId'den oluşan her bir satırın bir kez daha tekrar etmemesini için
             * bir Composit Primary Key tanımlaması yapıyoruz.
             */
            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });
            builder.ToTable("ProductCategories");
            builder.HasData(
                new ProductCategory { ProductId=1, CategoryId=1},
                new ProductCategory { ProductId=1, CategoryId=2},

                new ProductCategory { ProductId=2, CategoryId=1},
                new ProductCategory { ProductId=2, CategoryId=2},
                new ProductCategory { ProductId=2, CategoryId=3},

                new ProductCategory { ProductId=3, CategoryId=1},
                new ProductCategory { ProductId=3, CategoryId=3},

                new ProductCategory { ProductId=4, CategoryId=2},
                new ProductCategory { ProductId=4, CategoryId=3},

                new ProductCategory { ProductId=5, CategoryId=1},
                new ProductCategory { ProductId=6, CategoryId=2},
                new ProductCategory { ProductId=7, CategoryId=3},
                new ProductCategory { ProductId=8, CategoryId=4}
                );
        }
    }
}