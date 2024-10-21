using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.Servicos;

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

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) => {
    if(loginDTO.Email == "yasmimdemelo@gmail.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login con éxito");
    else 
        return Results.Unauthorized();
});

app.Run();