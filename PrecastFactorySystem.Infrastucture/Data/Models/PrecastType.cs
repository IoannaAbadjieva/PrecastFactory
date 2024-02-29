namespace PrecastFactorySystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Enums;

    using static Constants.DataConstants;

    public class PrecastType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PrecastTypeNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public PrecastReinforceType PrecastReinforceType { get; set; }

        public ICollection<Precast> Precasts = new HashSet<Precast>();
    }
}
