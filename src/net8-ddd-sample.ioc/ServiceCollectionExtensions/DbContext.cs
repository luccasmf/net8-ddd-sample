using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using net8_ddd_sample.infra.Context;

namespace net8_ddd_sample.ioc.ServiceCollectionExtensions
{
    public static class DbContext
    {
        #region Methods
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(connectionString));

        }
        #endregion

        public static void MigrateDb(this IServiceScope scope)
        {
            var _Db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            if (_Db != null)
            {
                if (_Db.Database.GetPendingMigrations().Any())
                {
                    _Db.Database.Migrate();
                }
            }

        }
    }
}
