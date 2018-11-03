using System.Collections.Generic;

namespace SPbSU.VK.TimeTable.Models
{
	public class User
	{
		public string Id { get; set; }
		public ICollection<Calendar> Calendars { get; set; }
	}
}
