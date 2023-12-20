using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<User> userManager;
		private SignInManager<User> signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if(ModelState.IsValid)
			{
				User user = new User();
				user.UserName = registerViewModel.UserName;
				var result = await userManager.CreateAsync(user, registerViewModel.Password);
				if(result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: true);
					RedirectToAction("Search", "Resume");
				} else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

		return View(registerViewModel);
		}
	}
}
