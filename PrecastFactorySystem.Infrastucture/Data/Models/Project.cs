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

        public ICollection<Precast> Precasts = new HashSet<Precast>();
    }
}
