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
            var subCategoryList = new List<SubCategory>();
            var productList = new List<Product>();
            var attributeGroupList = new List<AttributeGroup>();
            var oneAttributeList = new List<OneAttribute>();
            
            var oneAttribute = new OneAttribute
            {
                Name = "White",
                Description = "The color of this longsleeved shirt is white.",
                Type = "bool"
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
                Price = "999"
            };
            productList.Add(product);

            var subCategoryDataOne = new SubCategory
            {
                Name = "Long sleeve",
                Products = productList,
                AttributeGroups = attributeGroupList,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today
            };
            subCategoryList.Add(subCategoryDataOne);
            
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
        }
    }
}