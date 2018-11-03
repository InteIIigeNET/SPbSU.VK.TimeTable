using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.IServices;
using SPbSU.VK.TimeTable.Models;
using SPbSU.VK.TimeTable.ViewModels;
using System.Threading.Tasks;
using System.Transactions;

namespace SPbSU.VK.TimeTable.Services
{
	public class CalendarService : ICalendarService
	{
		private readonly IUserRepository userRepository;
		private readonly ICalendarRepository calendarRepository;

		public CalendarService(IUserRepository userRepository, ICalendarRepository calendarRepository)
		{
			this.userRepository = userRepository;
			this.calendarRepository = calendarRepository;
		}

		public async Task AddCalendar(long userId, CalendarViewModel calendarViewModel)
		{
			using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var calendar = await calendarRepository.CreateAsync(new Calendar
				{
					Group = calendarViewModel.Group,
					Title = calendarViewModel.Title
				});

				await userRepository.AddCalendar(userId, calendar);

				tran.Complete();				
			}
		}
	}
}
