using Datos;
using Logica.Classe;
using Logica.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<ApiComercioContext>(x => x.UseSqlServer(conn));


builder.Services.AddScoped<ICategoria, LogicaCategoria>();
builder.Services.AddScoped<IPorcentaje, LogicaPorcentaje>();
builder.Services.AddScoped<IProducto, LogicaProducto>();
builder.Services.AddScoped<IVentas, LogicaVentas>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
