using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    //  Crear una injeccion de independencia para el objeto
    private readonly DbContext _contexto;

    // Hacer un constructor para receber una injeccion de independencia
    public AdministradorServico(DbContext contexto)
    {
        _contexto = contexto;
    }

    // Agregar el metodo de DTOs
    public List<Administrador> Login(LoginDTO loginDTO)
    {
        throw new NotImplementedException();
    }
}