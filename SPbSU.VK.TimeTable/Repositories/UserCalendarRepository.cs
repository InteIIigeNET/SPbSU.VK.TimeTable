using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;

namespace SPbSU.VK.TimeTable.Repositories
{
	public class UserCalendarRepository : CrudRepository<UserCalendar>, IUserCalendarRepository
	{
		public UserCalendarRepository(VkTimeTableContext context) : base(context)
		{
		}
	}
}
