using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PracticalDemoWebAPI.DBContext;
using PracticalDemoWebAPI.Repository;
using PracticalDemoWebAPI.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddScoped<IConfiguration, IConfiguration>();
builder.Services.AddDbContext<DBContextClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarInventoryRepository, CarInventoryRepository>();
builder.Services.AddDbContext<DBContextClass>(options => options.UseSqlServer("DBContextClass"));
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
