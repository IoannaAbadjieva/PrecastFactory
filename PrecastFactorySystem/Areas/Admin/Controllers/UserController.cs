namespace PrecastFactorySystem.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	using PrecastFactorySystem.Core.Models.User;
	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	using static PrecastFactorySystem.Infrastructure.DataValidation.CustomClaims;
	using PrecastFactorySystem.Core.Models;
	using PrecastFactorySystem.Attributes;

	public class UserController : AdminBaseController
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<ApplicationRole> roleManager;
		private readonly IUserService userService;

		public UserController(UserManager<ApplicationUser> _userManager,
			RoleManager<ApplicationRole> _roleManager,
			 IUserService _userService)
		{
			userManager = _userManager;
			roleManager = _roleManager;
			userService = _userService;
		}

		public async Task<IActionResult> All()
		{
			var model = await userService.GetAllUsersAsync();
			return View(model);
		}

		[HttpGet]
		public IActionResult Register()
		{
			var model = new RegisterViewModel();
			model.Roles = roleManager.Roles;

			return View(model);
		}

		[HttpPost]
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
				await userManager.AddClaimAsync(user, new System.Security.Claims.Claim(UserFullName, $"{user.FirstName} {user.LastName}"));

				if (!string.IsNullOrEmpty(model.Role))
				{
					await userManager.AddToRoleAsync(user, model.Role);
				}
				else
				{
					await userManager.AddToRoleAsync(user, "User");
				}

				return RedirectToAction("Index", "Home");
			}

			foreach (var item in result.Errors)
			{
				ModelState.AddModelError("", item.Description);
			}

			return View(model);
		}

		[UserExists]
		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			var model = await userService.GetUserAsync(id);
			model.Roles = roleManager.Roles;

			return View(model);
		}

		[HttpPost]
		[UserExists]
		public async Task<IActionResult> Edit(string id, UserFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await userService.UpdateUserAsync(id, model);

			return RedirectToAction("All");
		}

		[UserExists]
		[HttpGet]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				UserInfoViewModel model = await userService.GetUserToDeleteAsync(id);
				return View(model);
			}
			catch (DeleteActionException dae)
			{
				return View("DeleteError", new BaseErrorViewModel { Message = dae.Message });
			}
		}

		[UserExists]
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			try
			{
				await userService.DeleteUserAsync(id);
				return RedirectToAction("All");
			}
			catch (DeleteActionException dae)
			{
				return View("DeleteError", new BaseErrorViewModel { Message = dae.Message });
			}
		}

		[HttpGet]
		public async Task<IActionResult> Roles()
		{
			IEnumerable<RoleInfoViewModel> model = await userService.GetAllRolesAsync();
			return View(model);
		}

	}
}
