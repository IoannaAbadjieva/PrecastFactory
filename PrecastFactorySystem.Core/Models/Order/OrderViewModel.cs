namespace PrecastFactorySystem.Core.Models.Order
{
	using System;
	using System.Collections.Generic;

	using PrecastFactorySystem.Core.Models.Reinforce;

	public class OrderViewModel
    {
        public int OrderNum { get; set; }

        public int PrecastId { get; set; }

        public string Precast { get; set; } = string.Empty;

        public string Project { get; set; } = string.Empty;

        public int Count { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; } 

        public int DelivererId { get; set; }

        public string DelivererEmail { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public string Department { get; set; } = string.Empty;

        public IEnumerable<ReinforceInfoViewModel> Reinforce { get; set; } = Array.Empty<ReinforceInfoViewModel>();

    }
}
