using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.Servicos;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Agragar un Scoped
builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

// Recuperar mi stringConexao despues de configurada em DbContexto
builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

// Agregar servicios para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) => {
    if(administradorServico.Login(loginDTO) != null)
        return Results.Ok("Login con éxito");
    else 
        return Results.Unauthorized();
});

//  Estos middlewares de Swagger, para la interfaz de usuario de Swagger en el navegador.
app.UseSwagger();
app.UseSwaggerUI();

app.Run();