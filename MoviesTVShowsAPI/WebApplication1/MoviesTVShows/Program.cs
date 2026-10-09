using Microsoft.EntityFrameworkCore;
using MoviesTVShows.Repository;
using MoviesTVShows.Repository.Common;
using MoviesTVShows.Service;
using MoviesTVShows.Service.Common;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IMovieRepository, MovieRepository>(); 
builder.Services.AddScoped<IMovieService, MovieService>(); 
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
