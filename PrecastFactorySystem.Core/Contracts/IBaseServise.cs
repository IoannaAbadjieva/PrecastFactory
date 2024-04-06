namespace PrecastFactorySystem.Core.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Models.Base;

	public interface IBaseServise
	{
		Task<IEnumerable<BaseSelectorViewModel>> GetProjectsAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetPrecastTypesAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetConcreteClassesAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetReinforceTypesAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetDeliverersAsync();

		Task<IEnumerable<BaseSelectorViewModel>> GetDepartmentsAsync();
	}
}
