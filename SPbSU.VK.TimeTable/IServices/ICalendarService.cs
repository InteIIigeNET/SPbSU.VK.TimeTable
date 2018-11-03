using SPbSU.VK.TimeTable.ViewModels;
using System.Threading.Tasks;

namespace SPbSU.VK.TimeTable.IServices
{
	public interface ICalendarService
	{
		Task AddCalendar(long userId, CalendarViewModel calendarViewModel);
	}
}
