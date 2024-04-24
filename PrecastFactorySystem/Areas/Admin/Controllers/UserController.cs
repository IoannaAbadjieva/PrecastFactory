namespace PrecastFactorySystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;

	using PrecastFactorySystem.Core.Models;
	using PrecastFactorySystem.Core.Models.User;
	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;
	using PrecastFactorySystem.Web.Attributes;

	using static PrecastFactorySystem.Infrastructure.DataValidation.CustomClaims;
	using static PrecastFactorySystem.Core.Constants.AdministratorConstants;

	public class UserController : AdminBaseController
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<ApplicationRole> roleManager;
		private readonly IUserService userService;
		private readonly IMemoryCache memoryCache;

		public UserController(UserManager<ApplicationUser> _userManager,
			RoleManager<ApplicationRole> _roleManager,
			 IUserService _userService,
			 IMemoryCache _memoryCache)
		{
			userManager = _userManager;
			roleManager = _roleManager;
			userService = _userService;
			memoryCache = _memoryCache;
		}

		public async Task<IActionResult> All()
		{
			var users = memoryCache.Get<IEnumerable<UserInfoViewModel>>(UsersCacheKey);

			if (users == null)
			{
				users = await userService.GetAllUsersAsync();
				memoryCache.Set(UsersCacheKey, users, new MemoryCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
				});
			}

			return View(users);
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

				memoryCache.Remove(UsersCacheKey);
				TempData["Message"] = "You have successfully registered user!";
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
			TempData["Message"] = "You have successfully updated user!";
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
				return View("BaseError", new BaseErrorViewModel { Message = dae.Message });
			}
		}

		[UserExists]
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			try
			{
				await userService.DeleteUserAsync(id);
				TempData["Message"] = "You have successfully deleted user!";
				return RedirectToAction("All");
			}
			catch (DeleteActionException dae)
			{
				return View("BaseError", new BaseErrorViewModel { Message = dae.Message });
			}
		}
	

	}
}
