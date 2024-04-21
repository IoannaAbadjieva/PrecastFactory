namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.User;

	public interface IUserService
	{
		Task<IEnumerable<UserInfoViewModel>> GetAllUsersAsync();
	}
}
