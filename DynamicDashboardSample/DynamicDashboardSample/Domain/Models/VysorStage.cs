using Microsoft.EntityFrameworkCore;

namespace DynamicDashboardSample.Domain.Models
{
    [PrimaryKey(nameof(VysorId), nameof(StageId))]
    public class VysorStage
    {
        public int VysorId { get; set; }
        public int StageId { get; set; }
        public Vysor? Vysor { get; set; } = null!;
        public Stage? Stage { get; set; } = null!;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int SizeW { get; set; }
        public int SizeH { get; set; }
        public string? Color { get; set; }
    }
}
