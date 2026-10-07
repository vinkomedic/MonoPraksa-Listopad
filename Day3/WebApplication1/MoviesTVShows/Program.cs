using MoviesTVShows.Repository;
using MoviesTVShows.Repository.Common;
using MoviesTVShows.Service;
using MoviesTVShows.Service.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMovieRepository, MovieRepository>(); // svi koriste isti repository i istu listu, app lifetime
builder.Services.AddTransient<IMovieService, MovieService>(); //samo koristi repository, per call
builder.Services.AddControllers();
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
