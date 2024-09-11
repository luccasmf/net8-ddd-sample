using Microsoft.EntityFrameworkCore;
using net8_ddd_sample.domain.Entities;
using net8_ddd_sample.domain.Interfaces.Repository;
using net8_ddd_sample.infra.Context;
using net8_ddd_sample.infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net8_ddd_sample.infra.Repository
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetListAsync()
        {
            return await base.GetList().OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await base.GetAsync(p => p.Id == id);
        }
    }
}
