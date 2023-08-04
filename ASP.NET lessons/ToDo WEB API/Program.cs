using ToDo_WEB_API.Data;
using ToDo_WEB_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDo_WEB_API.Auth;
using ToDo_WEB_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ToDoDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters =
        new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = "https://localhost:5000",
            ValidAudience = "https://localhost:5000",
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Hard Secure Key"))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanTest", policy =>
    {
        policy.RequireAuthenticatedUser();
        //policy.RequireClaim("CanTest");
        policy.Requirements.Add(new CanTestRequirment());
        
    });
});

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

    setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
    });

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                }, new string[]{ }
        }
    });
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
