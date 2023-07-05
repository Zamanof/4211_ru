using Microsoft.EntityFrameworkCore;
using MVCIntro.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebAppMVCContext>(options =>
    options.UseInMemoryDatabase("productDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute( //localhost:5277/home/index/25
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
