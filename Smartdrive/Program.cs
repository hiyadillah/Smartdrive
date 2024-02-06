using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Smartdrive.Db;
using Smartdrive.Extension;
using Smartdrive.Helpers;
using Smartdrive.Models;
using Smartdrive.Repositories;
using Smartdrive.Repositories.Master;
using Smartdrive.Repositories.Service_Order;
using Smartdrive.Repositories.UserModule;
using Smartdrive.Services.Master;
using Smartdrive.Services.UserModule;
using Swashbuckle.AspNetCore.Filters;
using System.IdentityModel.Tokens.Jwt;

//using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standar Authorization header using Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


//register auth
//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
//JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.MapInboundClaims = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:JwtSecret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            RoleClaimType = "akses",
        };
    });

// add auto mapper
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IRepository<CarBrand>, CarBrandRepository>();
builder.Services.AddScoped<ICarBrandService, CarBrandService>();

//users repo
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IBusinessEntityRepository, BusinessEntityRepository>();
builder.Services.AddScoped<IUserRolesRepository, UserRolesRepository>();

//users service
builder.Services.AddScoped<IUserService, UserService>();

//login helpers
builder.Services.AddScoped<JwtHelper>();

builder.Services.AddScoped<ServiceRepository>();
builder.Services.AddScoped<Mapper>();


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
