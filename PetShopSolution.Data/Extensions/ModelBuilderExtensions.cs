using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetShopSolution.Data.Entities;
using PetShopSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of PetShopSolution" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of PetShopSolution" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of PetShopSolution" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Chó", LanguageId = "vi-VN", SeoAlias = "cho", SeoDescription = "Sản phẩm cho chó", SeoTitle = "Sản phẩm cho chó" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Dog", LanguageId = "en-US", SeoAlias = "dog", SeoDescription = "Products for dog", SeoTitle = "Products for dog" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Mèo", LanguageId = "vi-VN", SeoAlias = "meo", SeoDescription = "Sản phẩm cho mèo", SeoTitle = "Sản phẩm cho mèo" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Cat", LanguageId = "en-US", SeoAlias = "cat", SeoDescription = "Products for cat", SeoTitle = "Products for cat" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Áo thun bestie",
                     LanguageId = "vi-VN",
                     SeoAlias = "ao-thun-bestie",
                     SeoDescription = "Áo thun bestie",
                     SeoTitle = "Áo thun bestie",
                     Details = "Áo thun bestie",
                     Description = "Áo thun bestie"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Bestie T-Shirt",
                        LanguageId = "en-US",
                        SeoAlias = "bestie -t-shirt",
                        SeoDescription = "Bestie T-Shirt",
                        SeoTitle = "Bestie T-Shirt",
                        Details = "Bestie T-Shirt",
                        Description = "Bestie T-Shirt"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "phuocnt150799@gmail.com",
                NormalizedEmail = "phuocnt150799@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Phuoc",
                LastName = "Nguyen",
                Dob = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 1,
                Status = Status.InActive,
                Content = "Content post 1",
                Tittle = "Title post 1",
                CreatedTime = DateTime.Now,
                UserId = adminId,
                ViewCount = 0,
            }, new Post
            {
                Id = 2,
                Status = Status.Active,
                Content = "Content post 2",
                Tittle = "Title post 2",
                CreatedTime = DateTime.Now,
                UserId = adminId,
                ViewCount = 5,
            }, new Post
            {
                Id = 3,
                Status = Status.Active,
                Content = "Content post 3",
                Tittle = "Title post 3",
                CreatedTime = DateTime.Now,
                UserId = adminId,
                ViewCount = 3,
            });
        }
    }
}
