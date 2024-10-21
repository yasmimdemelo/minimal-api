using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;
public class DbContexto : DbContext
{
    // Inyección de dependencias para la configuración
    private readonly IConfiguration _configuracaoAppSettings;

    // Constructor que recibe la configuración
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }

    // Definición del DbSet para Administrador
    public DbSet<Administrador> Administradores { get; set; } = default!;

    // Definición del Seed para la automatización de la inserción de datos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"                 
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Comprobar si ya está configurado
        if (!optionsBuilder.IsConfigured)
        {
            var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
            
            // Configuración de MySQL si la cadena de conexión no está vacía
            if (!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(
                    stringConexao,
                    ServerVersion.AutoDetect(stringConexao));
            }
        }
    }
}