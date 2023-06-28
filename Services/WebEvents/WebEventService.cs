using EventsWeb.Contexts;
using EventsWeb.Models;
using EventsWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb.Services.WebEvents
{
    public class WebEventService : IWebEventService
    {
        private WebEventContext context;

        public WebEventService(WebEventContext context)
        {
            this.context = context;
        }

        public async Task<WebEvent> Create(WebEvent newEvent)
        {
            this.context.Events.Add(newEvent);
            await this.context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<WebEvent> Delete(int id)
        {
            var entity = this.context.Events.SingleOrDefault(x => x.Id == id);
            if (entity!=null)
            {
                this.context.Events.Remove(entity);
                await this.context.SaveChangesAsync();
                
            }
            return entity;
        }

        public async Task<IEnumerable<WebEvent>> Fetch()
        {
            return await this.context.Events.ToListAsync();
        }

        public async Task<WebEvent> Fetch(int id)
        {
            return await this.context.Events.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
