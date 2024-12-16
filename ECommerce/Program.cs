using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

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
app.MapControllerRoute("pagination",
"Products/Page{productPage}",
new { Controller = "Home", action = "Index" }); app.MapDefaultControllerRoute(); //Simplyfing URLs to not use query string to pass page info to the server
SeedData.EnsurePopulated(app);

app.Run();