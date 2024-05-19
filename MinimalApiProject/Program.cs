using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApiProject;
using MinimalApiProject.Helpers;
using MinimalApiProject.Infrastructure;
using MinimalApiProject.Infrastructure.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Osoby API", Version = "v1" });
    c.SchemaFilter<SchemaFilter>();
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseInMemoryDatabase("Osoby"));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<JsonDbService>(provider =>
{
    var context = provider.GetRequiredService<ApplicationDbContext>();
    var filePath = builder.Configuration.GetValue<string>("JsonFile:filePath");
    return new JsonDbService(context, filePath);
});

var app = builder.Build();

var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

lifetime.ApplicationStopping.Register(() =>
{
    var scope = app.Services.CreateScope();
    var dataService = scope.ServiceProvider.GetRequiredService<JsonDbService>();
    dataService.SaveData();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var json = services.GetRequiredService<JsonDbService>();
    Seeder.Initialize(context, json);
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseErrorHandlingMiddleware();

app.MapGet("/Osoby", async (IRepository repository) =>
{
    var result = await repository.GetOsobyList();
    return Results.Ok(result);
});
app.MapGet("/Osoby/{id}", async (string id, IRepository repository) =>
{
    var result = await repository.GetOsobaById(id);
    return Results.Ok(result);
});
app.MapPost("/Osoby", async (AddOsoby osoba, IRepository repository) =>
{
    var result = await repository.AddOsoba(osoba);
    return Results.Created($"/Osoby/{result.ID}", result);
});

app.Run();
