using Abril25.ITD.PERROSPERDIDOS.APPLICATION.SERVICES;
using Abril25.ITD.PERROSPERDIDOS.DOMAIN.INTERFACES;
using Abril25.ITD.PERROSPERDIDOS.INFRAESTRUCTURE.REPOSITORIES;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IAdministradorRepository, AdministradorRepository>();
builder.Services.AddScoped<IMascotaPerdidaRepository, MascotaPerdidaRepository>();
builder.Services.AddScoped<AdministradorService>();
builder.Services.AddScoped<MascotaPerdidaService>();
builder.Services.AddTransient<IDbConnection>(db => new MySqlConnection("BDPPEROPERDIDO"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
