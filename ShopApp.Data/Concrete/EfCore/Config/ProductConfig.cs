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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p=>p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p=>p.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(p=>p.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(p => p.Url)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("money");
            builder.Property(p => p.CreatedDate)
                .HasDefaultValueSql("date('now')");//Sqlite için
                                                   //.HasDefaultValueSql("getdate()");//SqlServer için
            builder.Property(p => p.UpdatedDate)
                .HasDefaultValueSql("date('now')");
            builder.ToTable("Products");
            builder.HasData(
                new Product() { Id=1, Name = "Samsung S21", Price = 24000, Description = "İyi telefon", IsHome = true, ImageUrl = "1.png", Url = "samsung-s21" },
                new Product() { Id=2, Name = "Samsung S22", Price = 14000, Description = "Daha iyi telefon", IsHome = false, ImageUrl = "2.png", Url = "samsung-s22" },
                new Product() { Id=3, Name = "Samsung S23", Price = 18000, Description = "Bu da telefon mu?", IsHome = false, ImageUrl = "3.png", Url = "samsung-s23" },
                new Product() { Id=4, Name = "Iphone13", Price = 27000, Description = "Bu telefon değil", IsHome = true, ImageUrl = "4.png", Url = "iphone13" },
                new Product() { Id=5, Name = "Macbook Air M2", Price = 30000, Description = "Al, kafan rahat olsun", IsHome = true, ImageUrl = "17.png", Url = "macbook-air-m2" },
                new Product() { Id=6, Name = "Vestel Buzdolabı", Price = 19000, Description = "Yerli malı yurdun malı", IsHome = true, ImageUrl = "19.png", Url = "vestel-buzdolabi" },
                new Product() { Id=7, Name = "Arzum Okka", Price = 7800, Description = "Eskiden buralar dutluktu", IsHome = false, ImageUrl = "16.png", Url = "arzum-okka" },
                new Product() { Id=8, Name = "Xaomi Note 18", Price = 12500, Description = "Böyle bir şey de var", IsHome = false, ImageUrl = "12.png", Url = "xaomi-note-18" }
                );

        }
    }
}