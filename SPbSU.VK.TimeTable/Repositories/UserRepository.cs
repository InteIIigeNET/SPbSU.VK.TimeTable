using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;

namespace SPbSU.VK.TimeTable.Repositories
{
	public class UserRepository : CrudRepository<User>, IUserRepository
	{
		public UserRepository(VkTimeTableContext context) : base(context)
		{
		}
	}
}
