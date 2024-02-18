using DynamicDashboardSample.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicDashboardSample.Domain.Data
{
    public class DynamicDasboardDbContext : DbContext
    {
        public DynamicDasboardDbContext(DbContextOptions<DynamicDasboardDbContext> options) : base(options)
        {
        }

        public DbSet<Vysor> Vysor => Set<Vysor>();
        public DbSet<Stage> Stage => Set<Stage>();
        public DbSet<VysorStage> VysorStage => Set<VysorStage>();

    }
}
