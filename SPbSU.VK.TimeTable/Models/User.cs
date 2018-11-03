using System.Collections.Generic;

namespace SPbSU.VK.TimeTable.Models
{
	public class User : BaseModel
	{
		public string VkId { get; set; }
		public ICollection<UserCalendar> UserCalendars { get; set; } = new List<UserCalendar>();
	}
}
