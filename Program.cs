var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (MinimalApi.DTOs.LoginDTO loginDTO) => {
    if(loginDTO.Email == "yasmimdemelo@gmail.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login con éxito");
    else 
        return Results.Unauthorized();
});

app.Run();