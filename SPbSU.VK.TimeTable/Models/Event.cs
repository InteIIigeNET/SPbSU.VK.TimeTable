using System;

namespace SPbSU.VK.TimeTable.Models
{
	public class Event : BaseModel
	{
		public DateTime EventDateTime { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
