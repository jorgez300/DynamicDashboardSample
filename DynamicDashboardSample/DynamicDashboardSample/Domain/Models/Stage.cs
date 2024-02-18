using System.ComponentModel.DataAnnotations;

namespace DynamicDashboardSample.Domain.Models
{
    public class Stage
    {
        [Key]
        public int StageId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

    }
}
