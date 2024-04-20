namespace PrecastFactorySystem.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Core.Models.User;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

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

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public IActionResult Register()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			var model = new RegisterViewModel();

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = new ApplicationUser()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				UserName = model.UserName
			};

			var result = await userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				if (!string.IsNullOrEmpty(model.Role))
				{
					await userManager.AddToRoleAsync(user, model.Role);
				}
				else
				{
					await userManager.AddToRoleAsync(user, "User");
				}

				return RedirectToAction("Login", "User");
			}

			foreach (var item in result.Errors)
			{
				ModelState.AddModelError("", item.Description);
			}

			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("Index", "Home");
			}

			var model = new LoginViewModel();

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
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
					if (await userManager.IsInRoleAsync(user, "Administrator"))
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

		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
	}
}
