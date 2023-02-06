using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHealthChecks();

var app = builder.Build();

app.Map("/principal", builder =>
{
    builder.UseRouting();
    builder.UseEndpoints(routeBuilder =>
    {
        routeBuilder.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        routeBuilder.MapControllers();
    });
});
app.Run();
