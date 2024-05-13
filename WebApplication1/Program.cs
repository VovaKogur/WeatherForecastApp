using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WeatherForecast.Domain.Core;
using WeatherForecast.Domain.Service;
using WeatherForecast.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var applicationAssembly = Assembly.Load("WeatherForecast.Application");
var infrastructureAssembly = Assembly.Load("WeatherForecast.Infrastructure");

// Add services to the container.
builder.Services.AddDbContext<WeatherContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IWeatherContext, WeatherContext>();
builder.Services.AddScoped<IWeatherDomainService, WeatherDomainService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly, infrastructureAssembly));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
