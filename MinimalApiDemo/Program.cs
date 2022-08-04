using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Models;
using MinimalApiDemo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<RecruitmentContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/JobCategory", async (IRepository repo) => { return Results.Ok(await repo.GetJobCategories()); });
app.MapPost("api/JobCategory", async (IRepository repo, JobCategory category) =>
{

   var results= await repo.PostJobCategory(category);
    return category;

});

app.Run();

