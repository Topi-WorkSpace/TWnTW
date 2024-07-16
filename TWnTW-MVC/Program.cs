using Microsoft.EntityFrameworkCore;
using TWnTW_MVC.Data;
using TWnTW_MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var mongoDbSetting = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSetting>();
builder.Services.Configure<MongoDbSetting>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddDbContext<MongoDbContext>(opitons =>
{
    opitons.UseMongoDB(mongoDbSetting.AtlasUri ?? "", mongoDbSetting.DatabaseName ?? "");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
