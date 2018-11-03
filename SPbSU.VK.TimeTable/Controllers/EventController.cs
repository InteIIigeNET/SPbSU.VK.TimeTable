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
			using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var calendar = await calendarRepository.GetAsync(calendarId);

				var newEvent = new Event
				{
					Description = eventViewModel.Description,
					Title = eventViewModel.Title,
					EventDateTime = eventViewModel.EventDateTime
				};

				newEvent = await eventRepository.CreateAsync(newEvent);

				calendar.Events.Add(newEvent);

				tran.Complete();
			}
		}
    }
}