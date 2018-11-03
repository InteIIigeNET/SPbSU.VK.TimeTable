using Microsoft.EntityFrameworkCore;

namespace SPbSU.VK.TimeTable
{
	public class VkTimeTableContext : DbContext
	{
		public VkTimeTableContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
