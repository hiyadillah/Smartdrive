using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Master;
using Smartdrive.Services.Master;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<CarBrand>, CarBrandRepository>();
builder.Services.AddScoped<ICarBrandService, CarBrandService>();
builder.Services.AddDbContext<SmartdriveContext>(
    options => options.UseSqlServer("Server=CODEID-RAMA\\SQLEXPRESS; Initial Catalog=Smartdrive; Trusted_Connection=True; TrustServerCertificate=True;"));

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
