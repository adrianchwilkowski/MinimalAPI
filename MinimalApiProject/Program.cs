using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApiProject;
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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.MapGet("/PobierzListeOsob", async (IRepository repository) =>
{
    var result = await repository.GetOsobyList();
    return Results.Ok(result);
});
app.MapGet("/PobierzOsobe", async (Guid Id, IRepository repository) =>
{
    var result = await repository.GetOsobaById(Id);
    return Results.Ok(result);
});
app.MapPost("/DodajOsobe", async (AddOsoby osoba, IRepository repository) =>
{
    var result = await repository.AddOsoba(osoba);
    return Results.Ok(result);
});

app.Run();
