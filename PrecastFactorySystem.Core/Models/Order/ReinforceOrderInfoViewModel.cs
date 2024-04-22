namespace PrecastFactorySystem.Core.Models.Order
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReinforceOrderInfoViewModel
    {
        [Display(Name = "Order N")]
        public int Id { get; set; }

        public string OrderDate { get; set; }  = string.Empty;

        public string Project { get; set; } = string.Empty;

        public string PrecastType { get; set; } = string.Empty;

        public string Precast { get; set; } = string.Empty;

        public int OrderedCount { get; set; }

        public string DeliverDate { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string Deliverer { get; set; } = string.Empty;



    }
}
