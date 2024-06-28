using Microsoft.EntityFrameworkCore;
using SmartPhonesAPI.Data;
using SmartPhonesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ISmartphoneRepository,SmartPhoneRepository>();
builder.Services.AddDbContext<SmartPhoneDbContext>(options =>
{
    options.UseInMemoryDatabase("CustomerDb");
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


