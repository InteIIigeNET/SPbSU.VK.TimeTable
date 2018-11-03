using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;
using System.Threading.Tasks;

namespace SPbSU.VK.TimeTable.Repositories
{
	public class UserRepository : CrudRepository<User>, IUserRepository
	{
		public UserRepository(VkTimeTableContext context) : base(context)
		{
		}

		public async Task AddCalendar(long userId, Calendar calendar)
		{
			var user = await context.Users.FindAsync(userId);
			var userCalendar = new UserCalendar { CalendarId = calendar.Id, UserId = userId };

			user.UserCalendars.Add(userCalendar);
			await context.SaveChangesAsync();
		}
	}
}
