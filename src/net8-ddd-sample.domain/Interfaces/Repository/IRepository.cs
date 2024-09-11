using net8_ddd_sample.domain.Entities;

namespace net8_ddd_sample.domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity category);
        void Update(TEntity category);
        void Delete(TEntity category);
        Task<bool> SaveChangesAsync();
    }
}
