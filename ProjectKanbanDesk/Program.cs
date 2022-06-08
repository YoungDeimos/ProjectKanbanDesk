using ProjectKanbanDesk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ProjectKanbanDesk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionStory = "Server=(localdb)\\mssqllocaldb;Database=storydb;Trusted_Connection=True;";
            builder.Services.AddDbContext<StoryContext>(options => options.UseSqlServer(connectionStory));

            string connectionUser = "Server=(localdb)\\mssqllocaldb;Database=userdb;Trusted_Connection=True;";
            builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionUser));
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => options.LoginPath = "/login");
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("v1/swagger.json", "Notes API");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();


        }
    }
}