using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using net8_ddd_sample.application.Configuration;
using net8_ddd_sample.ioc.ServiceCollectionExtensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var dbConnectionString = configuration.GetConnectionString("DbConnectionString");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Configuration.AddEnvironmentVariables()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddDbContext(dbConnectionString);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureDependencyInjection();
builder.Services.AddOptions();
builder.Services.AddLocalization();
builder.Services.AddAuthentication(configuration);

// Healthz
builder.Services.ConfigureHealthz(dbConnectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.ConfigureLocalization();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

//HealthCheck Middleware
app.MapHealthChecks("/api/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

using (var scope = app.Services.CreateScope())
{
    scope.MigrateDb();
}

app.Run();
