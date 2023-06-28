
using EventsWeb.Contexts;
using EventsWeb.Services.Interfaces;
using EventsWeb.Services.WebEvents;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<WebEventContext>();
            builder.Services.AddScoped<IWebEventService, WebEventService>();


            
            
            var app = builder.Build();

            // now work on the migration

            using var scope=app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var dataContext = services.GetRequiredService<WebEventContext>();
                if (dataContext.Database.IsNpgsql())
                {
                    await dataContext.Database.MigrateAsync();
                }
            } catch(Exception ex)
            {
                throw ex;
            }
            
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
        }
    }
}