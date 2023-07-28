using ToDo_WEB_API.Data;
using ToDo_WEB_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "ToDo",
            Version = "v2"
        }
        );
    setup.IncludeXmlComments(@"obj\Debug\net6.0\ToDo WEB API.xml");
});

builder.Services.AddDbContext<ToDoDbContext>(
    options =>
       {
           options.UseSqlServer(builder.Configuration.GetConnectionString("TODO_DBContext"));
       }
    );

builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
