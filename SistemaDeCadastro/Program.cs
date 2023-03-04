
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaDeCadastro;
using SistemaDeCadastro.Data;
using SistemaDeCadastro.Interfaces;
using SistemaDeCadastro.Repositorios;
using System.Text;

public class Program
{


    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddEntityFrameworkSqlServer()
          .AddDbContext<SistemaDeCadastroDBContext>
            (
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );



        builder.Services.AddScoped<IEmpregadoRepositorio, EmpregadoRepositorio>();
        builder.Services.AddScoped<IProjetoRepositorio, ProjetoRepositorio>();

       

        

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}