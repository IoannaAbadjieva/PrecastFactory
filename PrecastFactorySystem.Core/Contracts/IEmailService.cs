namespace PrecastFactorySystem.Core.Contracts
{
	using System.Threading.Tasks;

	public interface IEmailService
	{
		Task SendOrderEmailAsync(string email, string fileName, byte[] bytes);

		Task SendCancelOrderEmailAsync(string email, string subject, string body);
	}
}
