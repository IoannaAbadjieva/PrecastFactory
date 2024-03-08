namespace PrecastFactorySystem.Core.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using PrecastFactorySystem.Core.Contracts;
	using PrecastFactorySystem.Infrastructure.Data.Common;

	public class PrecastService:IPrecastService
	{
		private readonly IRepository repository;

		public PrecastService(IRepository _repository)
		{
			repository = _repository;
		}
	}
}
