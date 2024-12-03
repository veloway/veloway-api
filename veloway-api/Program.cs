using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;
using veloway_api;
using Mapster;
using Core.DTOs;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//PostgreSQL connection
string connectionString = $"Server=ep-rough-term-a5bs9loc.us-east-2.aws.neon.tech;Port=5432;Database=veloway_db;User Id=veloway_db_owner;Password=iBYCSmV79Qct";
builder.Services.AddDbContext<VelowayDbContext>(options => options.UseNpgsql(connectionString));

//configuraciones de Mapster
var config = new TypeAdapterConfig();
config.NewConfig<Envio, EnvioDTO>()
    .Map(dest => dest.UsuarioNombre, src => src.IdClienteNavigation.Nombre)
    .Map(dest => dest.EstadoNombre, src => src.IdEstadoNavigation.Nombre)
    .Map(dest => dest.Origen, src => src.IdOrigenNavigation.Adapt<DomicilioDTO>())
    .Map(dest => dest.Destino, src => src.IdDestinoNavigation.Adapt<DomicilioDTO>());

config.NewConfig<Domicilio, DomicilioDTO>();

builder.Services.AddSingleton(config);
//builder.Services.AddScoped<IMapper, ServiceMapper>();

//ConfigureMapster.ConfigureMapping();

//Inyeccion de dependencias
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
