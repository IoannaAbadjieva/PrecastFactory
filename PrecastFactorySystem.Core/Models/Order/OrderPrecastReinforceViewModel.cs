namespace PrecastFactorySystem.Core.Models.Order
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

    using ValidationAttributes;
	using PrecastFactorySystem.Core.Models.Base;

	using static Infrastructure.DataValidation.DataConstants;
	using static Infrastructure.DataValidation.ErrorMessages;

	public class OrderPrecastReinforceViewModel
    {
        [Required]
        public int PrecastId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(PrecastCountMinValue, PrecastCountMaxValue,
            ErrorMessage = NumberRangeErrorMessage)]
        public int OrderedCount { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        public int DelivererId { get; set; }

        public IEnumerable<BaseInfoViewModel> Deliverers { get; set; } = Array.Empty<BaseInfoViewModel>();

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DeliverDateValidation]
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int DepartmentId { get; set; }

        public IEnumerable<BaseInfoViewModel> Departments { get; set; } = Array.Empty<BaseInfoViewModel>();

    }
}
