namespace PrecastFactorySystem.Core.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Core.Models.User;
	using PrecastFactorySystem.Infrastructure.Data.Common;
	using PrecastFactorySystem.Infrastructure.Data.Models.IdentityModels;
	public class UserService : IUserService
	{
		private readonly IRepository repository;
		private readonly RoleManager<ApplicationRole> roleManager;
		private readonly UserManager<ApplicationUser> userManager;

		public UserService(
			IRepository _repository, 
			RoleManager<ApplicationRole> _roleManager,
			UserManager<ApplicationUser> _userManager)
		{
			repository = _repository;
			roleManager = _roleManager;
			userManager = _userManager;
		}
		public async Task<IEnumerable<UserInfoViewModel>> GetAllUsersAsync()
		{
			return await repository.AllReadonly<ApplicationUser>()
				.Select( u => new UserInfoViewModel()
				{
					FullName = $"{u.FirstName} {u.LastName}",
					UserName = u.UserName,
					Email = u.Email,
					Role =  userManager.GetRolesAsync(u).Result[0],
				}).ToArrayAsync();

			
		}
		
	}
}
