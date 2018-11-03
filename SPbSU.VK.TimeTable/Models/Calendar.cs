using System.Collections.Generic;

namespace SPbSU.VK.TimeTable.Models
{
	public class Calendar : BaseModel
	{
		public ICollection<Event> Events { get; set; }
		public string Title { get; set; }
		public string Group { get; set; }

		public ICollection<UserCalendar> UserCalendars { get; set; } = new List<UserCalendar>();
	}
}
