using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Models;
using MinimalApiDemo.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<RecruitmentContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
builder.Services.AddSingleton<IMongoDatabase>(options => {
    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddSingleton<ICityRepository, CityRepository>();
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

app.MapGet("/api/City", async (ICityRepository repo) => { return Results.Ok(await repo.GetCityInformation()); });

app.MapPost("api/CityInformation", async (ICityRepository repo, CityInformation cityInformation) =>
{

    var results = await repo.AddCityInfo(cityInformation);
    return cityInformation;

});

app.Run();

