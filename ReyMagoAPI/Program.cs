using Microsoft.EntityFrameworkCore;
using ReyMagoApi.DataAccess;
using ReyMagoAPI.Core.Interfaces;
using ReyMagoAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//COnexion a la BAse de Datos
builder.Services.AddDbContext<AppDbContext>
    (options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")); });

//agregamos los repositorios
builder.Services.AddTransient<IGrimorioRepository, GrimorioRepositorio>();

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
