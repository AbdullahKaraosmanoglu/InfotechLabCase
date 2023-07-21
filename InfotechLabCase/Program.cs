using InfotechLabCase.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbContextInfotechLabCase>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("InfotechLabCaseCS")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
//{
//    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
//    opt.JsonSerializerOptions.AllowTrailingCommas = true;
//    opt.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString |
//        JsonNumberHandling.WriteAsString;
//    opt.JsonSerializerOptions.IncludeFields = true;
//});

//builder.Services.AddDbContext<DbContextInfotechLabCase>(options => options.UseInMemoryDatabase("DbInfotechLabCase"));

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
