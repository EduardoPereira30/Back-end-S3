using EventPlus.WebApi.BdContextEvent;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//adiciona o swaggeer
builder.Services.AddScoped<ITipoEventoRepository ,TipoEventoRepository>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Eventos",
        Description = "Aplicacao para gerenciamento de eventos",
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
        Name = "Authorizarion",
        Type = SecuritySchemeType.Http,
        Scheme= "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description= "Insira o token JWT"

    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
});

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();

        app.UseSwagger(options => { });

        app.UseSwaggerUI(options =>{
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
