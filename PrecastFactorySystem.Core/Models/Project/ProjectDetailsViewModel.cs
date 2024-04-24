namespace PrecastFactorySystem.Core.Models.Project
{
    using System.Collections.Generic;

    using PrecastFactorySystem.Core.Models.Precast;

    public class ProjectDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ProdNumber { get; set; } = string.Empty;

        public IEnumerable<PrecastInfoViewModel> Precast { get; set; } = Array.Empty< PrecastInfoViewModel>();
    }
}
