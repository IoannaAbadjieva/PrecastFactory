namespace PrecastFactorySystem.Infrastructure.Data.Contracts
{
	public interface IBaseEntity
	{
		int Id { get; set; }

		string Name { get; set; }
	}
}
