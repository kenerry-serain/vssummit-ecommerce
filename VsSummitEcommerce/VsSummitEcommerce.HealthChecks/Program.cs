using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHealthChecks();
builder.Services.AddHealthChecksUI(options =>
{
    options.SetEvaluationTimeInSeconds(5);
    options.MaximumHistoryEntriesPerEndpoint(10);
    //options.AddHealthCheckEndpoint("API com Health Checks", "/health");
})
.AddInMemoryStorage();

var app = builder.Build();

app.Map("/healthchecks", builder =>
{
    builder.UseRouting();
    builder.UseHttpsRedirection();
    builder.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });
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
