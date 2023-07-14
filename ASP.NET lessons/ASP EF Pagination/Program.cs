using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentsDbContext>(options =>
    options
    .UseSqlServer(
        builder
        .Configuration
        .GetConnectionString("StudentsDbContext")
        //,setting =>
        //{
        //    setting.CommandTimeout(30);
        //    setting.MigrationsHistoryTable("EF_TABLE_MIGRATIONS");
        //}        
        ));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
