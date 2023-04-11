using CloudinaryDotNet;
using DATN.NVDUONG.GracefulStyleShop.BL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.BL.Services;
using DATN.NVDUONG.GracefulStyleShop.Common.Models;
using DATN.NVDUONG.GracefulStyleShop.DL.Database;
using DATN.NVDUONG.GracefulStyleShop.DL.Helpers;
using DATN.NVDUONG.GracefulStyleShop.DL.Interfaces;
using DATN.NVDUONG.GracefulStyleShop.DL.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDL, ProductDL>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileDL, FileDL>();
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Bỏ bắn lỗi mặc định Atrribute
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Config respone để không chuyển hết về chữ thường
builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddSingleton(new Cloudinary(new Account(
    "dqywrcgrr",
    "511812445438653",
    "LaDWdP21mxTWyhZ2d5c08LkVYsk"
)));

// Get connectionString
DatabaseContext.connectionString = builder.Configuration.GetConnectionString("MySqlLocal");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("corspolicy");
app.MapControllers();

app.Run();
