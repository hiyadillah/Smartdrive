using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Master;
using Smartdrive.Repositories.Payment;
using Smartdrive.Services.Master;
using Smartdrive.Services.Payment;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<CarBrand>, CarBrandRepository>();
builder.Services.AddScoped<ICarBrandService, CarBrandService>();

builder.Services.AddScoped<IRepository<UserAccount>, UserAccountRepository>();
builder.Services.AddScoped<IUserAccountService, UserAccountsService>();


builder.Services.AddDbContext<SmartdriveContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SmartDriveDB")));
//builder.Services.AddDbContext<SmartdriveContext>(
//options => options.UseSqlServer("Server=DESKTOP-D6289E0\\SQLEXPRESS; Database = SmartDrive; Trusted_Connection=True; TrustServerCertificate=True;"));

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
