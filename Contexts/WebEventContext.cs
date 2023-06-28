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
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("defaultDb"));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<WebEvent> Events { get; set; }
    }
}
