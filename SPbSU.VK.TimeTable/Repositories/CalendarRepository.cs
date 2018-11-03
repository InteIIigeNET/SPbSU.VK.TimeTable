using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;

namespace SPbSU.VK.TimeTable.Repositories
{
	public class CalendarRepository : CrudRepository<Calendar>, ICalendarRepository
	{
		public CalendarRepository(VkTimeTableContext context) : base(context)
		{
		}
	}
}
