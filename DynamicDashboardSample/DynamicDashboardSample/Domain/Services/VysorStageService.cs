using DynamicDashboardSample.Domain.Data;
using DynamicDashboardSample.Domain.Models;
using DynamicDashboardSample.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DynamicDashboardSample.Domain.Services
{
    public class VysorStageService : IService<VysorStage>
    {
        protected DynamicDasboardDbContext db;

        public VysorStageService(DynamicDasboardDbContext db)
        {
            this.db = db;
        }

        public void Delete(VysorStage input)
        {
            db.VysorStage
                .Where(b => b.VysorId == input.VysorId && b.StageId == input.StageId)
                .ExecuteDelete();
            db.SaveChanges();
        }

        public List<VysorStage> GetList()
        {
            return db.VysorStage.ToList();
        }

        public List<VysorStage> GetListByVysor(int id)
        {
            return db.VysorStage
                .Where(b => b.VysorId == id)
                .Include(e => e.Stage)
                .ToList();
        }

        public VysorStage GetValue(VysorStage input)
        {
            return db.VysorStage.Single(b => b.VysorId == input.VysorId && b.StageId == input.StageId);
        }

        public void Insert(VysorStage input)
        {
            db.VysorStage.Add(input);
            db.SaveChanges();
        }

        public void Update(VysorStage input)
        {
            db.VysorStage.Update(input);
            db.SaveChanges();
        }


    }
}
