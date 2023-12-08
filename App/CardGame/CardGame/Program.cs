using CardGame.SQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net.WebSockets;

namespace CardGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS here
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost3000", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseWebSockets();

            // Use CORS before MapControllers
            app.UseCors("AllowLocalhost3000");

            app.MapControllers();

            ConnectionAccessor.TestDatabaseConnection();
            
            //DataInserter.playerLeaveRoom("splash35", "DJSDNKD");

            app.Run();
        }
    }
}
