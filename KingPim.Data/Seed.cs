using KingPim.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            var oneAttribute = new OneAttribute
            {
                Name = "White",
                Description = "The color of this longsleeved shirt is white.",
                Type = "string"
            };
            oneAttributeList.Add(oneAttribute);

            var attributeGroup = new AttributeGroup
            {
                Name = "Color",
                Description = "The color of the longsleeved shirt.",
                OneAttributes = oneAttributeList
            };
            attributeGroupList.Add(attributeGroup);

            var product = new Product
            {
                Name = "Ralph Lauren",
                Description = "Slim fit, long sleeved shirt.",
                Price = "999",
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
            };
            productList.Add(product);

            var subCategory = new SubCategory
            {
                Name = "Long sleeve",
                Products = productList,
                AttributeGroups = attributeGroupList,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false
            };
            subCategoryList.Add(subCategory);

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
                };
                // Adds the categories and all the connections behind:
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