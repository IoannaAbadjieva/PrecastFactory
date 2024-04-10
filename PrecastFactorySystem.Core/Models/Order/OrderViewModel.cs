namespace PrecastFactorySystem.Core.Models.Order
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Models.Reinforce;

	public class OrderViewModel
    {
        public int OrderNum { get; set; }

        public string Precast { get; set; } = string.Empty;

        public string Project { get; set; } = string.Empty;

        public int Count { get; set; }

        public string OrderDate { get; set; } = string.Empty;

        public string DeliverDate { get; set; } = string.Empty;

        public string Deliverer { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public IEnumerable<ReinforceInfoViewModel> Reinforce { get; set; } = Array.Empty<ReinforceInfoViewModel>();

    }
}
