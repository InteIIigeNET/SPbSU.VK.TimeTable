using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;

namespace SPbSU.VK.TimeTable.Repositories
{
	public class EventRepository : CrudRepository<Event>, IEventRepository
	{
		public EventRepository(VkTimeTableContext context) : base(context)
		{
		}
	}
}
