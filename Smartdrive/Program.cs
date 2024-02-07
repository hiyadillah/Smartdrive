using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.Extension;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Customer_Request;
using Smartdrive.Repositories.Customer_Request.Contract;
using Smartdrive.Repositories.Master;
using Smartdrive.Repositories.Service_Order;
using Smartdrive.Services.Customer_Request;
using Smartdrive.Services.Customer_Request.Contract;
using Smartdrive.Services.Master;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add auto mapper
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IRepository<CarBrand>, CarBrandRepository>();
builder.Services.AddScoped<ICarBrandService, CarBrandService>();
builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<Mapper>();

// Customer Modul inject services and repositories
builder.Services.AddScoped<ICustomerRequestRepository, CustomerRequestRepository>();
builder.Services.AddScoped<ICustomerRequestService, CustomerRequestService>();

builder.Services.AddDbContext<SmartdriveContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SmartDriveDB")));

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
