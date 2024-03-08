namespace PrecastFactorySystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.DataConstants;
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProjectNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ProjectNumberMaxLength)]
        public string ProdNumber { get; set; } = string.Empty;

        [Required]
        public DateTime AddedOn { get; set; }

        public ICollection<Precast> Precast = new HashSet<Precast>();
    }
}
