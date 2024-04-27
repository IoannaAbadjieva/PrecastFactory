namespace PrecastFactorySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.CodeAnalysis.CSharp.Syntax;

	using PrecastFactorySystem.Core.Models.User;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	using static PrecastFactorySystem.Core.Constants.AdministratorConstants;

	public class UserController : BaseController
	{
		private readonly UserManager<ApplicationUser> userManager;

		private readonly SignInManager<ApplicationUser> signInManager;

		public UserController(
			UserManager<ApplicationUser> _userManager,
			SignInManager<ApplicationUser> _signInManager)
		{
			userManager = _userManager;
			signInManager = _signInManager;
		}



		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			var model = new LoginViewModel();

			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await userManager.FindByNameAsync(model.UserName);

			if (user != null)
			{
				var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

				if (result.Succeeded)
				{
					if (await userManager.IsInRoleAsync(user, AdminRoleName))
					{
						return RedirectToAction("Index", "Home", new { area = "Admin" });
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}

				}
			}

			ModelState.AddModelError("", "Invalid login");

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult AccessDenied()
		{
			return RedirectToAction("Error", "Home", new { statusCode = 401 });
		}

	}
}
