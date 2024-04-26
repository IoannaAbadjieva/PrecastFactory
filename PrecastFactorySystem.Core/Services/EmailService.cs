namespace PrecastFactorySystem.Core.Services
{
	using System.Threading.Tasks;

	using Microsoft.Extensions.Configuration;

	using SendGrid;
	using SendGrid.Helpers.Mail;

	using PrecastFactorySystem.Core.Contracts;

	public class EmailService : IEmailService
	{

		private readonly IConfiguration configuration;

		private readonly string apiKey;

		public EmailService(IConfiguration _configuration)
		{
			configuration = _configuration;
			apiKey = configuration.GetSection("EmailSettings")["Sendgrid_API_Key"];
		}

		public async Task<bool> SendCancelOrderEmailAsync(string email, string subject)
		{
			var client = new SendGridClient(apiKey);
			var from = configuration.GetSection("EmailSettings")["From"];

			var fromAddress = new EmailAddress(from, "reinforce department");
			var toAddress = new EmailAddress(email, "Me");
			var body = $"{subject} has been canceled";
			var msg = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, body, "");

			var response = await client.SendEmailAsync(msg);

			return response.IsSuccessStatusCode;

		}

		public async Task<bool> SendOrderEmailAsync(string email, string fileName, byte[] bytes)
		{
			var client = new SendGridClient(apiKey);
			var from = configuration.GetSection("EmailSettings")["From"];

			var fromAddress = new EmailAddress(from, "reinforce department");
			var toAddress = new EmailAddress(email, "Me");
			var subject = fileName;
			var body = "Your order is ready for download";
			var msg = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, body, "");


			var attachment = new Attachment()
			{
				ContentId = "Attachment",
				Content = Convert.ToBase64String(bytes),
				Filename = fileName + ".pdf",
				Type = "application/pdf",
				Disposition = "attachment"
			};

			msg.AddAttachment(attachment);


			var response = await client.SendEmailAsync(msg);

			return response.IsSuccessStatusCode;
		}
	}

}
