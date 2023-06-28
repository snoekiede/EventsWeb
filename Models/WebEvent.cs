using Microsoft.EntityFrameworkCore;

namespace EventsWeb.Models
{
    public class WebEvent
    {
        
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }

    }
}
