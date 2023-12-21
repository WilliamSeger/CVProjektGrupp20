using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<User> userManager;
		private SignInManager<User> signInManager;
		private CVContext _context;

		public AccountController(CVContext context, UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			_context = context;
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

		[HttpGet]

		public IActionResult Login()
		{
			LoginViewModel loginViewModel = new LoginViewModel();
			return View(loginViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				var result = await signInManager.PasswordSignInAsync(
				loginViewModel.UserName, loginViewModel.Password, isPersistent: loginViewModel.RememberMe,
				lockoutOnFailure: false);
				if (result.Succeeded)
				{
					return RedirectToAction("Search", "Resume");
				}
				else
				{
					ModelState.AddModelError("", "Wrong username/password");
				}
			}
			return View(loginViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Search", "Resume");
		}

		[HttpGet]
		public IActionResult ChangePassword()
		{
			return View();
		}

		
		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel) 
		{


			string userName = User.Identity.Name;
			var result = from user in _context.Users
						   where user.UserName == userName
						   select user;
			User newUser = result.ToList()[0];
			await userManager.ChangePasswordAsync(newUser, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);

			return RedirectToAction("Search", "Resume");
		}
		
	}
}
