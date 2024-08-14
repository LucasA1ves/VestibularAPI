using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularAPI.Data;
using VestibularAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar o contexto do banco de dados
builder.Services.AddDbContext<VestibularContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar servi�os ao cont�iner
builder.Services.AddControllers(); // Adiciona suporte para controladores API

// Adicionar e configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de solicita��es HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // O valor padr�o do HSTS � 30 dias. Voc� pode querer alter�-lo para cen�rios de produ��o, veja https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // Mapeia os controladores API

// Configurar o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Adiciona a UI do Swagger
}

app.Run();
