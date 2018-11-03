using Microsoft.EntityFrameworkCore;
using SPbSU.VK.TimeTable.Models;

namespace SPbSU.VK.TimeTable
{
	public class VkTimeTableContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Calendar> Calendars { get; set; }


		public VkTimeTableContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
