using Microsoft.EntityFrameworkCore;
using net8_ddd_sample.domain.Entities;
using net8_ddd_sample.domain.Interfaces.Repository;
using net8_ddd_sample.infra.Context;
using net8_ddd_sample.infra.Repository.Base;

namespace net8_ddd_sample.infra.Repository
{
    public sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetListAsync()
        {
            return await base.GetList().OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await base.GetAsync(p => p.Id == id);
        }
    }
}
