using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Backend.API.Middlewares;
using TourOfHeroes.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TourOfHeroesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDataProviders();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
                .WithOrigins(app.Configuration.GetValue<string>("AppSettings:CorsAllowedOrigins")!.Split(","))
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

app.Run();

// Needed for tests
public partial class Program { }
