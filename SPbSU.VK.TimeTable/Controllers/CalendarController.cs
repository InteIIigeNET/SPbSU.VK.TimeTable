using Microsoft.AspNetCore.Mvc;
using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.IServices;
using SPbSU.VK.TimeTable.Models;
using SPbSU.VK.TimeTable.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SPbSU.VK.TimeTable.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CalendarController : ControllerBase
	{
		private readonly ICalendarRepository calendarRepository;
		private readonly IUserRepository userRepository;
		private readonly ICalendarService calendarService;
		private readonly IUserCalendarRepository userCalendarRepository;

		public CalendarController(ICalendarRepository calendarRepository, IUserRepository userRepository, ICalendarService calendarService, IUserCalendarRepository userCalendarRepository)
		{
			this.calendarRepository = calendarRepository;
			this.userRepository = userRepository;
			this.calendarService = calendarService;
			this.userCalendarRepository = userCalendarRepository;
		}

		[HttpPost]
		public async Task<ActionResult> Add(long userId, [FromBody]CalendarViewModel calendarViewModel)
		{
			await calendarService.AddCalendar(userId, calendarViewModel);
			return Ok();
		}

		[HttpPost]
		public async Task<ActionResult> Update(long calendarId, [FromBody]CalendarViewModel calendarViewModel)
		{
			var isSuceed = await calendarRepository.UpdateAsync(calendarId, _ => new Calendar
			{
				Title = calendarViewModel.Title,
				Group = calendarViewModel.Group
			});

			if (isSuceed)
				return Ok();
			return NotFound();
		}

		[HttpGet]
		public ActionResult GetAll(long userId)
		{
			var userCalendars = userCalendarRepository.FindAll(uc => uc.UserId == userId, uc => uc.Calendar);

			return Ok(userCalendars.Select(uc => uc.Calendar));
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(long id)
		{
			var isSuceed = await calendarRepository.DeleteAsync(id);
			if (isSuceed)
				return Ok();
			return NotFound();
		}
	}
}
