using DynamicDashboardSample.Domain.Data;
using DynamicDashboardSample.Domain.Models;
using DynamicDashboardSample.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DynamicDashboardSample.Domain.Services
{
    public class VysorService : IService<Vysor>
    {
        protected DynamicDasboardDbContext db;

        public VysorService(DynamicDasboardDbContext db)
        {
            this.db = db;
        }

        public void Delete(Vysor input)
        {     
            db.Vysor.Where(b => b.VysorId == input.VysorId).ExecuteDelete();
            db.SaveChanges();
        }

        public List<Vysor> GetList()
        {
            return db.Vysor.ToList();
        }

        public Vysor GetValue(Vysor input)
        {
           return db.Vysor.Single(b => b.VysorId == input.VysorId);
        }

        public Vysor GetValueById(int id)
        {
            return db.Vysor.Single(b => b.VysorId == id);
        }

        public void Insert(Vysor input)
        {
            db.Vysor.Add(input);
            db.SaveChanges();
        }

        public void Update(Vysor input)
        {
            db.Vysor.Update(input);
            db.SaveChanges();
        }
    }
}
