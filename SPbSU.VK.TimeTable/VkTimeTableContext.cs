using Microsoft.EntityFrameworkCore;
using SPbSU.VK.TimeTable.Models;

namespace SPbSU.VK.TimeTable
{
	public class VkTimeTableContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Calendar> Calendars { get; set; }
		public DbSet<UserCalendar> UserCalendars { get; set; }


		public VkTimeTableContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserCalendar>()
			.HasKey(t => new { t.UserId, t.CalendarId });

			modelBuilder.Entity<UserCalendar>()
				.HasOne(sc => sc.Calendar)
				.WithMany(s => s.UserCalendars)
				.HasForeignKey(sc => sc.CalendarId);

			modelBuilder.Entity<UserCalendar>()
				.HasOne(sc => sc.User)
				.WithMany(c => c.UserCalendars)
				.HasForeignKey(sc => sc.UserId);
		}
	}
}
