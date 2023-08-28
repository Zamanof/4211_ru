using ToDo_WEB_API.Data;
using ToDo_WEB_API.Services;
using Microsoft.EntityFrameworkCore;
using ToDo_WEB_API;
using FluentValidation.AspNetCore;
using ToDo_WEB_API.DTOs.Auth;
using FluentValidation;
using ToDo_WEB_API.DTOs.Validation;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AuthenticationAndAuthorization(builder.Configuration);

builder.Services.AddSwagger();

builder.Services.AddDbContext<ToDoDbContext>(
    options =>
       {
           options.UseSqlServer(builder.Configuration.GetConnectionString("TODO_DBContext"));
       }
    );

builder.Services.AddScoped<ITodoService, TodoService>();

Log.Logger = new LoggerConfiguration()
    //.MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.WithProcessName()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .WriteTo.Console(outputTemplate: "{Timestamp: yyyy / MM / dd   HH:mm:ss} {Level:w3} " +
    "{Message: lj} " +
    "{NewLine}" +
    "ThreadId: {ThreadId} {NewLine}" +
    "ThreadName: {ThreadName}{NewLine}" +
    "ProcessName: {ProcessName}"+
    "{Exception}" +
    "{NewLine}")
    //.WriteTo.File("log.txt",
    //            rollingInterval: RollingInterval.Day,
    //            rollOnFileSizeLimit: true)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddLogging(options =>
        {
            //options.SetMinimumLevel(LogLevel.Debug);
            //options.AddJsonConsole();
        }
    );

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
