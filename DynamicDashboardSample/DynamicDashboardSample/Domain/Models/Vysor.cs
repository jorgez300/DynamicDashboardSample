using System.ComponentModel.DataAnnotations;

namespace DynamicDashboardSample.Domain.Models
{
    public class Vysor
    {
        [Key]
        public int VysorId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

    }
}
