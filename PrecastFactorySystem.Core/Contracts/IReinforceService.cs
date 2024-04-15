namespace PrecastFactorySystem.Core.Contracts
{
    using System.Collections.Generic;

    using Models.Reinforce;

    using PrecastFactorySystem.Core.Models.Base;
    using PrecastFactorySystem.Core.Models.Order;

    public interface IReinforceService
	{
		Task<int> EditReinforceAsync(int id, ReinforceFormViewModel model);

		Task<int> DeleteReinforceAsync(int id);

		Task<ReinforceFormViewModel?> GetReinforceByIdAsync(int id);

		Task<bool> IsReinforceExist(int id);
		
	}
}
