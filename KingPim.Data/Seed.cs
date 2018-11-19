using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Data
{
    public class Seed
    {
        public static void FillIfEmpty(ApplicationDbContext ctx)
        {
            // The list variables created for the Seed():
            var categoryList = new List<Category>();
            var subCategoryList = new List<SubCategory>();
            var productList = new List<Product>();
            var attributeGroupList = new List<AttributeGroup>();
            var oneAttributeList = new List<OneAttribute>();
            var subCategoryAttributeGroupList = new List<SubCategoryAttributeGroup>();

            // Attribute:
            var oneAttribute = new OneAttribute
            {
                Name = "Color",
                Description = "The specific color of the product.",
                Type = "string"
            };
            ctx.OneAttributes.Add(oneAttribute);
            ctx.SaveChanges();


            // AttributeGroup:
            var attributeGroup = new AttributeGroup
            {
                Name = "Style",
                Description = "The style of the product.",
                OneAttributes = oneAttributeList
            };
            ctx.AttributeGroups.Add(attributeGroup);
            ctx.SaveChanges();

            // Product:
            var product = new Product
            {
                Name = "Ralph Lauren",
                Description = "Slim fit, long sleeved shirt.",
                Price = "999",
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1,
                ModifiedByUser = "administrator@kingpim.se"
            };
            productList.Add(product);

            // SubCategory:
            var subCategory = new SubCategory
            {
                Name = "Long sleeve",
                Products = productList,
                SubCategoryAttributeGroups = subCategoryAttributeGroupList,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1,
                ModifiedByUser = "administrator@kingpim.se"
            };
            subCategoryList.Add(subCategory);

            // SubCategoryAttributeGroups:
            var subCategoryAttributeGroups = new SubCategoryAttributeGroup
            {
                SubCategory = ctx.SubCategories.FirstOrDefault(x => x.Id == 1),
                AttributeGroup = ctx.AttributeGroups.FirstOrDefault(x => x.Id == 1)
            };
            subCategoryAttributeGroupList.Add(subCategoryAttributeGroups);

            // Category:
            if (!ctx.Categories.Any())
            {
                var category = new Category
                {
                    Name = "Shirts",
                    SubCategories = subCategoryList,
                    UpdatedDate = DateTime.Now.Date,
                    AddedDate = DateTime.Now,
                    Published = false,
                    Version = 1,
                    ModifiedByUser = "administrator@kingpim.se"
                };
                ctx.Categories.AddRange(category);
            };
            ctx.SaveChanges();

            // Connect a product to a attribute to productoneattributevalues:
            if (!ctx.ProductOneAttributeValues.Any())
            {
                var productTryout = ctx.Products.FirstOrDefault(x => x.Id == 1);

                var attributeTryout = ctx.OneAttributes.FirstOrDefault(x => x.Id == 1);

                var productAttributeValue = new ProductOneAttributeValue
                {
                    Value = "White",
                    Product = productTryout,
                    OneAttribute = attributeTryout
                };
                ctx.ProductOneAttributeValues.Add(productAttributeValue);
                ctx.SaveChanges();
            }
        }
    }
}