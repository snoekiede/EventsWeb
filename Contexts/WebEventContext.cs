using EventsWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb.Contexts
{
    public class WebEventContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public WebEventContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbHost = Environment.GetEnvironmentVariable("HOST");
            var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
            var userName = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

            var connectionString = string.Empty;
            if (string.IsNullOrEmpty(dbHost) || 
                string.IsNullOrEmpty(dbName) || 
                string.IsNullOrEmpty(userName) || 
                string.IsNullOrEmpty(password))
            {
                connectionString = Configuration.GetConnectionString("defaultDb");
            }
            else
            {
                connectionString = $"Host={dbHost};Database={dbName};Username={userName};Password={password}";
            }
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<WebEvent> Events { get; set; }
    }
}
