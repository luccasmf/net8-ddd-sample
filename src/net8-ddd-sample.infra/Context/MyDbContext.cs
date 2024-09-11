using Microsoft.EntityFrameworkCore;
using net8_ddd_sample.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net8_ddd_sample.infra.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new Mapping.CategoryConfiguration());
            builder.ApplyConfiguration(new Mapping.ProductConfiguration());
        }
    }
}
