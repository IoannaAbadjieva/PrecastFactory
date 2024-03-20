namespace PrecastFactorySystem.Core.Models.Precast
{
    public class PrecastDetailsViewModel : PrecastInfoViewModel
    {
        public string AddeOn { get; set; } = string.Empty;
        public string ConcreteClass { get; set; } = string.Empty;

        public decimal ConcreteProjectAmount { get; set; }

        public decimal ReinforceProjectAmount { get; set; }

    }
}
