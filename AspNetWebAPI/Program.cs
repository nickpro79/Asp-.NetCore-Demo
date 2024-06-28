using AspNetWebAPI.Data;
using AspNetWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICustomerRepository, CustomerEFCoreInMemoryRepository>();
builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    options.UseInMemoryDatabase("CustomerDb");
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
