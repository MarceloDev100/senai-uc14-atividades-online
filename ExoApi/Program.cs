using System.Reflection;
using ExoApi.Contexts;
using ExoApi.Repositories;
using ExoApi.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors( options =>
  {
      options.AddPolicy("CorsPolicy", builder => 
      {
          builder.WithOrigins("http://localhost:3000")
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
  }
);

builder.Services.AddAuthentication(options =>
{
   options.DefaultAuthenticateScheme = "JwtBearer";
   options.DefaultChallengeScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        IssuerSigningKey = new
        SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao")),
        ClockSkew = TimeSpan.FromMinutes(60),
        ValidIssuer = "exoapi.webapi",
        ValidAudience = "exoapi.webapi"
    };
});

builder.Services.AddScoped<ProjetoContext, ProjetoContext>();
builder.Services.AddTransient<IProjetoRepository, ProjetoRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(doc => {
   doc.SwaggerDoc("v1", new OpenApiInfo{
        Version = "v1",
        Title = "UC14 - SENAI-SP - Projeto ExoApi",
        Description = "Modelo simplificado de uma Web API para gerenciar projetos.",
        Contact = new OpenApiContact 
        { 
            Name = "Aluno: Marcelo Marques." ,
            Url = new Uri("https://github.com/MarceloDev100")
        }    
   });
     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
     var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
     doc.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExoApi");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
