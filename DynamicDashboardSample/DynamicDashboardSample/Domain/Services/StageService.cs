using DynamicDashboardSample.Domain.Data;
using DynamicDashboardSample.Domain.Models;
using DynamicDashboardSample.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DynamicDashboardSample.Domain.Services
{
    public class StageService : IService<Stage>
    {
        protected DynamicDasboardDbContext db;

        public StageService(DynamicDasboardDbContext db)
        {
            this.db = db;
        }

        public void Delete(Stage input)
        {
            db.Stage.Where(b => b.StageId == input.StageId).ExecuteDelete();
            db.SaveChanges();
        }

        public List<Stage> GetList()
        {
            return db.Stage.ToList();
        }

        public Stage GetValue(Stage input)
        {
            return db.Stage.Single(b => b.StageId == input.StageId);
        }

        public void Insert(Stage input)
        {
            db.Stage.Add(input);
            db.SaveChanges();
        }

        public void Update(Stage input)
        {
            db.Stage.Update(input);
            db.SaveChanges();
        }


    }
}
