using System.Collections.Generic;

namespace SPbSU.VK.TimeTable.Models
{
	public class Calendar : BaseModel
	{
		public ICollection<Event> Events { get; set; }
		public string Title { get; set; }
	}
}
