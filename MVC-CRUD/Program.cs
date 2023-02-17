using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;


var builder = WebApplication.CreateBuilder(args);

// 設定連線字串
string connection = builder.Configuration.GetConnectionString("LinkToDb");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CompanyContext>(options =>
{
    options.UseSqlServer(connection);
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
