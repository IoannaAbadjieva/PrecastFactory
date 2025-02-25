﻿namespace PrecastFactorySystem.Core.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Exceptions;
	using PrecastFactorySystem.Core.Models.User;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;

	using static PrecastFactorySystem.Core.Constants.AdministratorConstants;
	using static PrecastFactorySystem.Core.Constants.MessageConstants;

	public class UserService : IUserService
	{
		private readonly IRepository repository;
		private readonly UserManager<ApplicationUser> userManager;

		public UserService(
			IRepository _repository,
			UserManager<ApplicationUser> _userManager)
		{
			repository = _repository;
			userManager = _userManager;
		}
		public async Task<IEnumerable<UserInfoViewModel>> GetAllUsersAsync()
		{
			return await repository.AllReadonly<ApplicationUser>()
				.Select(u => new UserInfoViewModel()
				{
					Id = u.Id.ToString(),
					FullName = $"{u.FirstName} {u.LastName}",
					UserName = u.UserName,
					Email = u.Email,
					Role = userManager.GetRolesAsync(u).Result[0],
				}).ToArrayAsync();


		}

		public async Task<UserFormViewModel> GetUserAsync(string id)
		{
			var user = await userManager.FindByIdAsync(id);

			return new UserFormViewModel()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserName = user.UserName,
				Email = user.Email,
				Role = userManager.GetRolesAsync(user).Result[0],
			};
		}

		public async Task UpdateUserAsync(string id, UserFormViewModel model)
		{
			var user = await userManager.FindByIdAsync(id);

			user.FirstName = model.FirstName;
			user.LastName = model.LastName;
			user.UserName = model.UserName;
			user.Email = model.Email;

			var result = await userManager.UpdateAsync(user);

			if (result.Succeeded)
			{
				var roles = await userManager.GetRolesAsync(user);

				if (!string.IsNullOrWhiteSpace(model.Role) && model.Role != roles[0])
				{
					await userManager.RemoveFromRoleAsync(user, roles[0]);
					await userManager.AddToRoleAsync(user, model.Role);
				}

			}

		}

		public async Task<UserInfoViewModel> GetUserToDeleteAsync(string id)
		{
			var user = await userManager.FindByIdAsync(id);

			if (await userManager.IsInRoleAsync(user, AdminRoleName))
			{
				throw new DeleteActionException(DeleteAdminErrorMessage);
			}

			return new UserInfoViewModel()
			{
				Id = user.Id.ToString(),
				FullName = $"{user.FirstName} {user.LastName}",
				UserName = user.UserName,
				Email = user.Email,
				Role = userManager.GetRolesAsync(user).Result[0],
			};
		}

		public async Task DeleteUserAsync(string id)
		{
			var user = await userManager.FindByIdAsync(id);

			if (await userManager.IsInRoleAsync(user, AdminRoleName))
			{
				throw new DeleteActionException(DeleteAdminErrorMessage);
			}

			await userManager.DeleteAsync(user);
		}
		
	}
}
