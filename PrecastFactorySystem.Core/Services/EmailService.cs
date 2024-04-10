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

		public EmailService(IConfiguration _configuration)
		{
			configuration = _configuration;
		}
		public async Task SendEmailAsync(string email, string fileName)
		{
			var apiKey = configuration.GetSection("EmailSettings")["Sendgrid_API_Key"];

			var client = new SendGridClient(apiKey);
			var from = configuration.GetSection("EmailSettings")["From"];
			
			var fromAddress = new EmailAddress(from, "Yoanna");
			var toAddress = new EmailAddress(email, "Me");
			var subject = fileName;
			var body = "Your order is ready for download";
			var msg = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, body, "");

			var currentDirectory = Directory.GetCurrentDirectory();
			var directory = Directory.GetParent(currentDirectory) + "\\Orders";
			var attachmentPath = directory + "\\" + fileName + ".pdf";

			var attachment = new Attachment() 
			{
				ContentId = "Attachment",
				Content = Convert.ToBase64String(File.ReadAllBytes(attachmentPath)),
				Filename = fileName + ".pdf",
				Type = "application/pdf",
				Disposition = "attachment"
			};
			
			msg.AddAttachment(attachment);
	

			var response = await client.SendEmailAsync(msg);
			
		
		}
	}

}
