using DAL;
using Microsoft.EntityFrameworkCore;
using NetCoreWebApp1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database used in Admin panel
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("NetCoreWebApp1") ??
    throw new InvalidOperationException("Connection string 'NetCoreWebApp1Context' not found.")));

// Database used in DAL
//builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("NetCoreWebApp1") ??
//    throw new InvalidOperationException("Connection string 'NetCoreWebApp1Context' not found.")));

builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);


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
            name: "admin",
            pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
