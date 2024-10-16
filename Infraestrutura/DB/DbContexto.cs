using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;


public class DbContexto : DbContext

{
    // Crear una injeccion de independencia para el objeto
    private readonly IConfiguration _configuracaoAppSettings;
    
    // Hacer un constructor para receber una injeccion de independencia
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
       _configuracaoAppSettings = configuracaoAppSettings;
    }

    public DbSet<Administrador> Adiministradores { get; set;} = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // variable para usar el iten de la injeccion de independencia
        // ? = Si no encuentra nada, regresa vacio
        var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();

        // Agregar validacion "if" de optionsBuilder, despues de configuracion en Program.CS
        if(!optionsBuilder.IsConfigured)
        {
            // Configuracion que passamos en el construtor
            if (!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(
                    stringConexao, 
                    ServerVersion.AutoDetect(stringConexao));
            }
        }
    }
}