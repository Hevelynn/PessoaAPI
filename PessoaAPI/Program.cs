using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PessoaAPI;
using PessoaAPI.Data.Context;
using PessoaAPI.Repository;
using PessoaAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("PessoaConnection");

//builder.Services.AddDbContext<FluentContext>(options => 
//options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<FluentContext>(o => o.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=pessoaapi;Integrated Security=True;TrustServerCertificate=True;"));

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var chave = Encoding.ASCII.GetBytes(Settings.Segredo);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(chave),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Adicionar o serviço do seu serviço de Pessoa, se você tiver um.
builder.Services.AddScoped<PessoaRepository>();
builder.Services.AddScoped<PessoaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
