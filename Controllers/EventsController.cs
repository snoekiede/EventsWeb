using EventsWeb.Models;
using EventsWeb.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EventsWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IWebEventService webEventService;

        public EventsController(IWebEventService webEventService)
        {
            this.webEventService = webEventService;
        }

        [HttpGet]
        [Route("/")]
        public async Task<JsonResult> Fetch()
        {
            var events = await webEventService.Fetch();
            return new JsonResult(events);
        }

        [HttpGet]
        [Route("event/{id}")]
        public async Task<IActionResult> FetchEvent(int id)
        {
            var webEvent = await webEventService.Fetch(id);
            if (webEvent==null)
            {
                return NotFound();
            } else
            {
                return new JsonResult(webEvent);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]WebEvent newEvent)
        {
            if (newEvent == null)
            {
                return Problem();
            } else
            {
                var createdEvent=await this.webEventService.Create(newEvent);
                return Created(Request.GetDisplayUrl(), createdEvent);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.webEventService.Delete(id);
            return Ok();
        }
    }
}
