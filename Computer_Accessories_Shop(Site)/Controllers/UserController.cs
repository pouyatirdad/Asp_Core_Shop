using Computer_Accessories_Shop.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Computer_Accessories_Shop_Site_.Controllers
{
	[Authorize(Roles = "User")]
	public class UserController : Controller
	{
		private readonly UserManager<User> userManager;

		public UserController(UserManager<User> userManager)
		{
			this.userManager = userManager;
		}
		public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            return View(user);
		}
	}
}
