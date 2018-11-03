namespace SPbSU.VK.TimeTable.Models
{
	public class UserCalendar : BaseModel
	{
		public long UserId { get; set; }
		public User User { get; set; }

		public long CalendarId { get; set; }
		public Calendar Calendar { get; set; }
	}
}
