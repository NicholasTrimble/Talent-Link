using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{ 
 opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//addcors to allow localhost to run together.
builder.Services.AddCors();
builder.Services.AddScoped<ITokenService, TokenService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.UseHttpsRedirection();
app.MapControllers();





app.Run();
