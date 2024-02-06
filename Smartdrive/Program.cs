using Microsoft.EntityFrameworkCore;
using Smartdrive.Db;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Master;
using Smartdrive.Repositories.Partners;
using Smartdrive.Services.Master;
using Smartdrive.Services.Partners;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<CarBrand>, CarBrandRepository>();
builder.Services.AddScoped<ICarBrandService, CarBrandService>();
builder.Services.AddDbContext<SmartdriveContext>(
    options =>
    {
        options
        .UseSqlServer("Server=DESKTOP-QVUVQTV\\SQLEXPRESSCA;Database=SmartDrive;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
    }
);

// Module Partner Inject Services and Repositories
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
builder.Services.AddScoped<IPartnerService,  PartnerService>();
builder.Services.AddScoped<IPartnerContactService, PartnerContactService>();
builder.Services.AddScoped<IPartnertContactRepository, PartnerContactRepository>();
builder.Services.AddScoped<IPartnerAreaWorkgroupRepository, PartnerAreaWorkgroupRepository>();
builder.Services.AddScoped<IPartnerAreaWorkgroupService, PartnerAreaWorkgroupService>();


builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

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
