using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Repositories;
using RestauranteAPI.Repositories.Interface;
using RestauranteAPI.Services;
using RestauranteAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RestauranteContext>(options => options.UseMySql(stringConnection,
    ServerVersion.AutoDetect(stringConnection)));

builder.Services.AddScoped(typeof(IRepositoryTotalFlexBase<>), typeof(RepositoryTotalFlexBase<>));
builder.Services.AddScoped<IPratoService, PratoService>();

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
