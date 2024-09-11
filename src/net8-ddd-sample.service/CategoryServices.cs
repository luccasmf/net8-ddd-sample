using net8_ddd_sample.domain.Entities;
using net8_ddd_sample.domain.Interfaces.Repository;
using net8_ddd_sample.domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net8_ddd_sample.services
{
    public sealed class CategoryServices : ICategoryServices
    {
        #region Variables
        private readonly ICategoryRepository _repository;
        #endregion

        #region Constructors
        public CategoryServices(ICategoryRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Category>> GetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            if (id > 0)
                return await _repository.GetAsync(id);
            return null;
        }

        public async Task<bool> AddAsync(Category category)
        {
            await _repository.AddAsync(category);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            ValidateToSave(category, true);

            _repository.Update(category);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _repository.Delete(await GetAsync(id));
            return await _repository.SaveChangesAsync();
        }

        /// <summary>
        /// Example for validation of business rules.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="update"></param>
        private void ValidateToSave(Category category, bool update)
        {
            if (update)
            {
                if (category.Id < 1)
                    throw new ApplicationException($"Invalid {nameof(category.Id)} to update the {nameof(category)}.");
            }

            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ApplicationException($"Empty ({nameof(category.Name)}) for the {nameof(category)}.");
        }
        #endregion
    }
}
