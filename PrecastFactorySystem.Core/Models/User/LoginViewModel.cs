﻿namespace PrecastFactorySystem.Core.Models.User
{
	using System.ComponentModel.DataAnnotations;

	public class LoginViewModel
	{
		[Required]
		public string UserName { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

	}
}
