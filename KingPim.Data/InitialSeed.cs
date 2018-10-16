using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Data
{
    public class InitialSeed
    {
        public static void FillIfEmpty(ApplicationDbContext ctx)
        {
            // ProductCatalog:
            if (!ctx.ProductCatalogs.Any())
            {
                ctx.ProductCatalogs.Add(new ProductCatalog { Id = 1, CategoryId = 1});

                ctx.SaveChanges();
            }

            // Categories:
            if (!ctx.Categories.Any())
            {
                ctx.Categories.Add(new Category { Id = 1, Name = "Tröjor", SubCategoryId = 1 });

                ctx.SaveChanges();
            }

            // SubCategories:
            if (!ctx.SubCategories.Any())
            {
                ctx.SubCategories.Add(new SubCategory {Id = 1, Name = "Långarmat", ProductId = 1 });

                ctx.SaveChanges();
            }

            // AttributeGroups:
            if (!ctx.AttributeGroups.Any())
            {
                ctx.AttributeGroups.Add(new AttributeGroup {Id = 1, Name = "AttributeGroup Test", ProductAttributeId = 1 });

                ctx.SaveChanges();
            }

            // ProductAttributes:
            if (!ctx.ProductAttributes.Any())
            {
                ctx.ProductAttributes.Add(new ProductAttribute {Id = 1, Make = "Ralph Lauren", Material = "Bomull", Colour = "Grå", Size = "M", Price = 199 });
                
                ctx.SaveChanges();
            }

            // Products:
            if (!ctx.Products.Any())
            {
                ctx.Products.Add(new Product {Id = 1, AttributeGroupId = 1 });

                ctx.SaveChanges();
            }
        }
    }
}
