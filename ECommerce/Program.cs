using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Connection String: " + builder.Configuration.GetConnectionString("StoreConnection"));

// Configure services
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();


var app = builder.Build();

// Configure middleware
app.UseStaticFiles();
app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);

app.Run();