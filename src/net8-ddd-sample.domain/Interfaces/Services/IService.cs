using net8_ddd_sample.domain.Entities;

namespace net8_ddd_sample.domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<TEntity> GetAsync(int id);
        Task<bool> AddAsync(TEntity category);
        Task<bool> UpdateAsync(TEntity category);
        Task<bool> DeleteAsync(int id);
    }
}
