using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    //  Crear una injeccion de independencia para el objeto
    private readonly DbContexto _contexto;

     // Inyectar DbContexto en el constructor
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    // Agregar el método de DTO
    public Administrador? Login(LoginDTO loginDTO)
    {
        // Utilizar el DbSet correctamente en el contexto
        var adm = _contexto.Administradores
            .Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha)
            .FirstOrDefault();
        return adm;
    }
}