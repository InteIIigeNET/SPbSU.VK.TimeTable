using SPbSU.VK.TimeTable.Models;
using System.Threading.Tasks;

namespace SPbSU.VK.TimeTable.IRepositories
{
	public interface IUserRepository : ICrudRepository<User>
	{
		Task AddCalendar(long userId, Calendar calendar);
	}
}
