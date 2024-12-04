using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;
using veloway_api;
//using Mapster;
using Mapster;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//PostgreSQL connection
string connectionString = $"Server=ep-rough-term-a5bs9loc.us-east-2.aws.neon.tech;Port=5432;Database=veloway_db;User Id=veloway_db_owner;Password=iBYCSmV79Qct";
builder.Services.AddDbContext<VelowayDbContext>(options => options.UseNpgsql(connectionString));


// Register Mapster
builder.Services.AddMapster();

// Configure Mapster
MapsterConfig.Configure();

builder.Services.AddScoped<IEnvioService, EnvioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
