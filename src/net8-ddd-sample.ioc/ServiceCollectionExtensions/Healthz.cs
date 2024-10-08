﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace net8_ddd_sample.ioc.ServiceCollectionExtensions
{
    public static class Healthz
    {
        public static void ConfigureHealthz(this IServiceCollection services, string connectionString)
        {
            services.AddHealthChecks().AddNpgSql(
                            connectionString ?? "",
                            healthQuery: "SELECT 1;",
                            name: connectionString is null ? "sql-without-connection" : "sql",
                            failureStatus: HealthStatus.Unhealthy,
                            tags: new string[] { "db", "sql", "postgresql" }
                    );
        }
    }
}
