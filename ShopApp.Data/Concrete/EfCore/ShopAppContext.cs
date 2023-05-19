using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Concrete.EfCore.Config;
using ShopApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.EfCore
{
    public class ShopAppContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ShopApp.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Eğer ayrı ayrı config dosyaları hazırlamazsak, burada alttaki satırlarda görüldüğü gibi configürasyonlar yapılmalıdır.
            //modelBuilder.Entity<Category>().HasKey(c => c.Id);
            //modelBuilder.Entity<Category>().ToTable("Kategoriler");
            //modelBuilder.Entity<Category>().Property(c => c.Url).IsRequired().HasMaxLength(300);
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());


            base.OnModelCreating(modelBuilder);
        }
    }
}