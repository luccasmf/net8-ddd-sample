using net8_ddd_sample.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
