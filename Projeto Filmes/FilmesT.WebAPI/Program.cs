using FilmesT.WebAPI.BdContextFilme;
using FilmesT.WebAPI.Interfaces;
using FilmesT.WebAPI.Repositories;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
var builder = WebApplication.CreateBuilder(args);


// contexto do banco de dados (com SQL Server)
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoty>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";

}).AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,

        //valida  quem esta recebendo
        ValidateAudience = true,

        //define se o tempo de expiracao sera validado
        ValidateLifetime = true,

        //forma de criptografia e valida a chave de autentificacao
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes
             ("filmes-chave-autentificacao-webapi-dev")),

        //valida o tempo de expiracao do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //nome do issuer (de onde esta vindo)
        ValidIssuer = "api-filmes",

        //nome do audience (para onde ele esta indo)
        ValidAudience = "api-filmes"
    };
});

builder.Services.AddControllers();

var app = builder.Build();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
