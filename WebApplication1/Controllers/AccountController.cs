using Microsoft.AspNetCore.Authorization;
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
					TempData["AlertMessage"] = "User was registered succesfully";
					return RedirectToAction("CreateProfile", "Profile");
				} else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

			return View();
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

		[Authorize]
		[HttpGet]
		public IActionResult ChangePassword()
		{
			ChangePasswordViewModel viewModel = new ChangePasswordViewModel();
			return View(viewModel);
		}

		
		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel) 
		{
			var users = _context.Users;
			User user = users.Where(user => user.UserName == User.Identity.Name).First();
			await userManager.ChangePasswordAsync(user, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);
			TempData["AlertMessage"] = "Password was updated succesfully";

			return RedirectToAction("Search", "Resume");
		}

        [Authorize]
        [HttpGet]
        public IActionResult ChangeUserName()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserName(ChangeUserNameViewModel changeUserNameViewModel)
        {


			var users = _context.Users;
			User user = users.Where(user => user.UserName == User.Identity.Name).First();
			user.UserName = changeUserNameViewModel.NewUserName;
            await userManager.UpdateAsync(user);
			TempData["AlertMessage"] = "Username was updated succesfully";

			return RedirectToAction("Search", "Resume");
        }

    }
}
