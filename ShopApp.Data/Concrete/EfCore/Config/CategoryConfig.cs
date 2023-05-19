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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Category Properties
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder
                .Property(c => c.Url)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("date('now')");
            builder.Property(c => c.UpdatedDate)
                .HasDefaultValueSql("date('now')");
            builder
                .ToTable("Categories");
            //Data Insert
            builder
                .HasData(
                            new Category() { Id = 1, Name = "Telefon", Description = "Telefonlar bu kategoride", Url = "telefon", IsApproved = true, IsDeleted=false },
                            new Category() { Id = 2, Name = "Bilgisayar", Description = "Bilgisayarlar bu kategoride", Url = "bilgisayar", IsApproved = true, IsDeleted = false },
                            new Category() { Id = 3, Name = "Elektronik", Description = "Elektronik ürünler bu kategoride", Url = "elektronik", IsApproved = true, IsDeleted = false },
                            new Category() { Id = 4, Name = "Beyaz Eşya", Description = "Beyaz eşya ürünleri bu kategoride", Url = "beyaz-esya", IsApproved = true, IsDeleted = false }
                ) ;
        }
    }
}