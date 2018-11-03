using Microsoft.AspNetCore.Mvc;
using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;
using SPbSU.VK.TimeTable.ViewModels;
using System.Threading.Tasks;
using System.Transactions;

namespace SPbSU.VK.TimeTable.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
		private readonly IEventRepository eventRepository;
		private readonly ICalendarRepository calendarRepository;

		public EventController(IEventRepository eventRepository, ICalendarRepository calendarRepository)
		{
			this.eventRepository = eventRepository;
			this.calendarRepository = calendarRepository;
		}

		[HttpPost]
		public async Task<ActionResult> Add(long calendarId, [FromBody]EventViewModel eventViewModel)
		{
			var newEvent = new Event
			{
				Description = eventViewModel.Description,
				Title = eventViewModel.Title,
				EventDateTime = eventViewModel.EventDateTime,
				CalendarId = calendarId
			};

			await eventRepository.CreateAsync(newEvent);

			return Ok();
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(long id)
		{
			var isSuceed = await eventRepository.DeleteAsync(id);
			if (isSuceed)
				return Ok();
			return NotFound();
		}

		[HttpPost]
		public async Task<ActionResult> Update(long eventId, EventViewModel eventViewModel)
		{
			var isSuceed = await eventRepository.UpdateAsync(eventId, e => new Event
			{
				Description = eventViewModel.Description,
				Title = eventViewModel.Title,
				EventDateTime = eventViewModel.EventDateTime
			});

			if (isSuceed)
				return Ok();
			return NotFound();
		}

		[HttpGet]
		public async Task<ActionResult> Get(long id)
		{
			return Ok(await eventRepository.GetAsync(id));
		}

		[HttpGet]
		public async Task<ActionResult> GetAll(long calendarId)
		{
			return Ok(eventRepository.FindAll(e => e.CalendarId == calendarId));
		}
    }
}