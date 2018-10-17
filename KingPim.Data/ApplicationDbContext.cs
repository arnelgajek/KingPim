using KingPim.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OneAttribute> OneAttributes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOneAttributeValue> ProductOneAttributeValues { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
    }
}
