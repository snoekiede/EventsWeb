using EventsWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb.Contexts
{
    public class WebEventContext:DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public WebEventContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("connectionstring");
            if (String.IsNullOrEmpty(connectionString))
            {
                connectionString = Configuration.GetConnectionString("defaultDb");
            }
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<WebEvent> Events { get; set; }
    }
}
