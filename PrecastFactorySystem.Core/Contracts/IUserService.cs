namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.User;

	public interface IUserService
	{
		Task<IEnumerable<UserInfoViewModel>> GetAllUsersAsync();

		Task<UserFormViewModel> GetUserAsync(string id);

		Task UpdateUserAsync(string id, UserFormViewModel model);

		Task<UserInfoViewModel> GetUserToDeleteAsync(string id);

		Task DeleteUserAsync(string id);

		Task<IEnumerable<RoleInfoViewModel>> GetAllRolesAsync();
	}
}
