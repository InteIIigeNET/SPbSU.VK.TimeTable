using Microsoft.AspNetCore.Mvc;
using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;
using System.Threading.Tasks;

namespace SPbSU.VK.TimeTable.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
		private readonly IUserRepository userRepository;

		public UserController(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		[HttpPost]
		public async Task<ActionResult> Add(string vkId)
		{
			await userRepository.CreateAsync(new User
			{
				VkId = vkId
			});
			return Ok();
		}
    }
}