using Microsoft.AspNetCore.Mvc;
using net8_ddd_sample.domain.Entities;
using net8_ddd_sample.domain.Interfaces.Services;

namespace net8_ddd_sample.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryServices.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetAsync(int id)
        {
            return await _categoryServices.GetAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddAsync([FromBody] Category category)
        {
            return await _categoryServices.AddAsync(category);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync([FromBody] Category category)
        {
            return await _categoryServices.UpdateAsync(category);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryServices.DeleteAsync(id);
        }
    }
}
