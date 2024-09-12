using AutoMapper;
using net8_ddd_sample.application.DTO.Responses;
using net8_ddd_sample.domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
