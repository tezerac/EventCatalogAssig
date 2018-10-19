using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EventCatalogAPI.ViewModel;

namespace EventCatalogAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

    [Produces("application/json")]
    [Route("api/Event")]
    public class EventCatalogController : ControllerBase

    {
        private readonly EventContext _eventContext;
        private readonly IConfiguration _configuration;
        public EventCatalogController(EventContext eventContext, IConfiguration configuration)
        {
            _eventContext = eventContext;
            _configuration = configuration;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var eventTypes = await _eventContext.EventTypes.ToListAsync();
            return Ok(eventTypes);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTopics()
        {
            var eventTopics = await _eventContext.EventTopics.ToListAsync();
            return Ok(eventTopics);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventVenues()
        {
            var eventVenues = await _eventContext.EventVenues.ToListAsync();
            return Ok(eventVenues);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Organizers()
        {
            var organizers = await _eventContext.Organizers.ToListAsync();
            return Ok(organizers);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Events(
           [FromQuery] int pageSize = 6,
            [FromQuery] int pageIndex = 0
            )
        {
            var totalEvents = await _eventContext.Events.LongCountAsync();
            var eventsOnPage = await _eventContext.Events.OrderBy(c => c.EventName)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            eventsOnPage = ChangeUrlPlaceholder(eventsOnPage);
            return Ok(eventsOnPage);
        }
        //GET api/Event/Events/?pageSize=2&pageIndex=0
        //GET api/Event/Events/withname/xxxxx
        [HttpGet]
        [Route("[action]/withname/{eventName:minlength(1)}")]
        public async Task<IActionResult> Events(string eventName,
        [FromQuery] int pageSize = 6,
         [FromQuery] int pageIndex = 0
         )
        {
            var totalEvents = await 
                _eventContext.Events
                .Where(c => c.EventName.StartsWith(eventName))
                .LongCountAsync();
               
            var eventsOnPage = await _eventContext.Events
                .Where(c => c.EventName.StartsWith(eventName))
                .OrderBy(c => c.EventName)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            eventsOnPage = ChangeUrlPlaceholder(eventsOnPage);
            return Ok(eventsOnPage);
        }


        // GET api/Event/Events/eventTopics/1/eventTypes/2
        [HttpGet]
        [Route("[action]/topic/{eventTopicId}/type/{eventTypeId}")]
        //this will be like: //type/1/topic/3
        //the two names should much in{} and ?
        public async Task<IActionResult> Items(
             //nullable types
             int? eventTopicId,
             int? eventTypeId,

             [FromQuery] int pageSize = 6,
             [FromQuery] int pageIndex = 0
            )
        //create the entire query before it is excuted
            {
            var root = (IQueryable<CatalogEvent>)_eventContext.Events;

            if (eventTypeId.HasValue)
            {
                root = root.Where(c => c.EventTypeID 
                == eventTypeId);
            }
            if (eventTopicId.HasValue)
            {
                root = root.Where(c => c.EventTopicID 
                == eventTopicId);
            }

            var totalEvents = await 
                root.LongCountAsync();
            var eventsOnPage = await root
                .OrderBy(c => c.EventName)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            eventsOnPage = ChangeUrlPlaceholder(eventsOnPage);

            var model = new PaginatedEventViewModel<CatalogEvent>
                (pageIndex, pageSize, totalEvents, eventsOnPage);

            return Ok(model);
        }

        [HttpGet]
        [Route("events/{id:int}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();//returns 400 bad request
            }
            var events = await _eventContext.Events.SingleOrDefaultAsync(c => c.EventID == id);
            if (events != null)
            {
                events.EventImageUrl = events.EventImageUrl.Replace
            ("http://externalcatalogbaseurltobereplaced",
            _configuration["ExternalCatalogBaseUrl"]);
                return Ok(events);
            
            }
            return NotFound();
        }
        private List<CatalogEvent> ChangeUrlPlaceholder(List<CatalogEvent> events)
        {
            events.ForEach(x => x.EventImageUrl = x.EventImageUrl.Replace
            ("http://externalcatalogbaseurltobereplaced",
            _configuration["ExternalCatalogBaseUrl"]));
            return events;
        }

    }
}