using EventsWeb.Models;

namespace EventsWeb.Services.Interfaces
{
    public interface IWebEventService
    {
        Task<IEnumerable<WebEvent>> Fetch();
        Task<WebEvent> Fetch(int id);
        Task<WebEvent> Create(WebEvent newEvent);
        Task<WebEvent> Delete(int id);
    }
}
