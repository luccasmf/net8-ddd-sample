using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using net8_ddd_sample.infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net8_ddd_sample.ioc.ServiceCollectionExtensions
{
    public static class DbContext
    {
        #region Methods
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase(connectionString));

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
