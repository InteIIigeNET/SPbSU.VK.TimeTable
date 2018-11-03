using System;

namespace SPbSU.VK.TimeTable.Models
{
	public class Event
	{
		public DateTime EventDateTime { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public long Id { get; set; }
	}
}
