namespace PrecastFactorySystem.Core.Models.Produce
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PrecastFactorySystem.Core.Models.Base;
    using PrecastFactorySystem.Core.ValidationAttributes;
    using static PrecastFactorySystem.Infrastructure.DataValidation.DataConstants;
    using static PrecastFactorySystem.Infrastructure.DataValidation.ErrorMessages;

    public class ProduceFormViewModel
    {
        [Required]
        public int PrecastId { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(PrecastCountMinValue, PrecastCountMaxValue,
            ErrorMessage = NumberRangeErrorMessage)]
        public int ProducedCount { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        [ProductionDateValidation]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int DepartmentId { get; set; }

        public IEnumerable<BaseInfoViewModel> Departments { get; set; } = Array.Empty<BaseInfoViewModel>();


    }
}
