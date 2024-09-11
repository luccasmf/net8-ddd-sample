using Microsoft.Extensions.DependencyInjection;
using net8_ddd_sample.domain.Interfaces.Repository;
using net8_ddd_sample.domain.Interfaces.Services;
using net8_ddd_sample.infra.Repository;
using net8_ddd_sample.services;

namespace net8_ddd_sample.ioc.ServiceCollectionExtensions
{
    public static class DependencyInjection
    {
        #region Methods
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            // Services
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IProductServices, ProductServices>();

            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        #endregion
    }
}
