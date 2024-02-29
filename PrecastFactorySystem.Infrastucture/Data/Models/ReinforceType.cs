namespace PrecastFactorySystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Enums;

    public class ReinforceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ReinforceClass ReinforceClass { get; set; }

        [Required]
        public int Diameter { get; set; }

        public decimal SpecificMass 
            => (decimal)(Math.Pow(this.Diameter / 2.0, 2) * Math.PI);

        public ICollection<PrecastReinforce> PrecastReinforce = new HashSet<PrecastReinforce>();


    }
}
