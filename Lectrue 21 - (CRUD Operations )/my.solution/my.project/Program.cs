using Microsoft.EntityFrameworkCore;
using my.project.DbModels;
using my.project.Infrastructure.Implementation;
using my.project.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EVS407Context>(x => x.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EVS-407;Trusted_Connection=True;"));

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddControllersWithViews();


//Register Db Context 
//var connectionString = builder.Configuration.GetConnectionString("AppDb");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseRouting();

app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
