using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;


public class DbContexto : DbContext
{
    public DbSet<Administrador> Adiministradores { get; set;} = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "string de conexão", 
            ServerVersion.AutoDetect("string de conexão"));
    }
}