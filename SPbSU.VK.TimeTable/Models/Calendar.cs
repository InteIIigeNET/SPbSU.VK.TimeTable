using System.Collections.Generic;

namespace SPbSU.VK.TimeTable.Models
{
	public class Calendar
	{
		public long Id { get; set; }
		public ICollection<Event> Events { get; set; }
		public string Title { get; set; }
	}
}
