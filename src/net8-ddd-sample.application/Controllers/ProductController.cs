using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net8_ddd_sample.application.DTO.Responses;
using net8_ddd_sample.domain.Entities;
using net8_ddd_sample.domain.Interfaces.Services;

namespace net8_ddd_sample.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductController(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductResponse>> ListAsync()
        {
            var products = await _productServices.GetListAsync();

            // Example with AutoMapper
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetAsync(int id)
        {
            return await _productServices.GetAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddAsync([FromBody] Product product)
        {
            return await _productServices.AddAsync(product);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync([FromBody] Product product)
        {
            return await _productServices.UpdateAsync(product);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _productServices.DeleteAsync(id);
        }
    }
}
