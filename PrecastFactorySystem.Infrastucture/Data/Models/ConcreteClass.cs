﻿namespace PrecastFactorySystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static DataValidation.DataConstants;

	public class ConcreteClass
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(ConcreteClassNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Required]
		public int CompressiveStrengthRequired { get; set; }

		public ICollection<Precast> Precast { get; set; } = new HashSet<Precast>();
	}
}