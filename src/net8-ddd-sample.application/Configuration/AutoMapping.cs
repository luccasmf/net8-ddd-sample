using AutoMapper;
using net8_ddd_sample.application.DTO.Responses;
using net8_ddd_sample.domain.Entities;

namespace net8_ddd_sample.application.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductResponse>();
        }
    }
}
