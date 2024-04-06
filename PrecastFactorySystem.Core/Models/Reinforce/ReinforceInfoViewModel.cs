namespace PrecastFactorySystem.Core.Models.Reinforce
{
	using System;
	using System.Collections.Generic;

	using Base;

	public class ReinforceInfoViewModel
    {
	    public int Id { get; set; }

	    public int PrecastId { get; set; }

	    public string Position { get; set; } = string.Empty;

		public int Count { get; set; }

        public string ReinforceType { get; set; } = string.Empty;

		public decimal Length { get; set; }
    }
}
