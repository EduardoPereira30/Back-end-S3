using FilmesT.WebAPI.BdContextFilme;
using FilmesT.WebAPI.Interfaces;
using FilmesT.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
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
        ValidIssuer = "api_filmes",

        //nome do audience (para onde ele esta indo)
        ValidAudience = "api_filmes",
    };
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Filmes API",
        Description = "Uma API com catalogos de filmes",
        TermsOfService = new Uri("Https://exemple.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "EduardoPereira30",
            Url = new Uri("https://github.com/EduardoPereira30")
        },
        License = new OpenApiLicense
        {
            Name = "Exemplo License",
            Url = new Uri("Https://exemple.com/License")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT: "

    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = 
        Array.Empty<string>().ToList()
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();