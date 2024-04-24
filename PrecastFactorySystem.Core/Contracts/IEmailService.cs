namespace PrecastFactorySystem.Core.Contracts
{
	using System.Threading.Tasks;

	public interface IEmailService
	{
		Task<bool> SendOrderEmailAsync(string email, string fileName, byte[] bytes);

		Task<bool> SendCancelOrderEmailAsync(string email, string subject, string body);
	}
}
