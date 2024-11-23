using BuscaPersonalApi.AutoMapper;
using BuscaPersonalApi.Data;
using BuscaPersonalApi.Repositories;
using BuscaPersonalApi.Repositories.Interface;
using BuscaPersonalApi.Services;
using BuscaPersonalApi.Utils;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
Env.Load();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<PersonalService>();
builder.Services.AddScoped<ValidarUtils>();
builder.Services.AddScoped<IPersonal, PersonalRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperPofile));
builder.Services.AddSwaggerGen();


string? connectionString = Environment.GetEnvironmentVariable("URL");

builder.Services.AddDbContext<AppDbContext>(option => 
    option.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
