﻿namespace PrecastFactorySystem.Core.Contracts
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public interface IEmailService
	{
		Task SendEmailAsync(string email, string fileName);
	}
}
