using DynamicDashboardSample.Domain.Models;
using DynamicDashboardSample.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DynamicDashboardSample.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class VysorController : ControllerBase
    {
        protected readonly VysorService vysorService;

        public VysorController(VysorService vysorService)
        {
            this.vysorService = vysorService;
        }


        [HttpGet]
        public IEnumerable<Vysor> GetAll()
        {
            return this.vysorService.GetList();
        }

        [HttpGet]
        public Vysor Get(Vysor input)
        {
            return this.vysorService.GetValue(input);
        }

        [HttpGet]
        public Vysor GetValueById(int id)
        {
            return this.vysorService.GetValueById(id);
        }
        // POST api/<VysorController>
        [HttpPost]
        public void Post([FromBody] Vysor input)
        {
            this.vysorService.Insert(input);
        }

        // PUT api/<VysorController>/5
        [HttpPut]
        public void Put([FromBody] Vysor input)
        {
            this.vysorService.Update(input);
        }

        // DELETE api/<VysorController>/5
        [HttpDelete]
        public void Delete([FromBody] Vysor input)
        {
            this.vysorService.Delete(input);
        }
    }
}
