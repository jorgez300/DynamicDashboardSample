using DynamicDashboardSample.Domain.Models;
using DynamicDashboardSample.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DynamicDashboardSample.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        protected readonly StageService stageService;

        public StageController(StageService stageService)
        {
            this.stageService = stageService;
        }

        [HttpGet]
        public IEnumerable<Stage> GetAll()
        {
            return this.stageService.GetList();
        }

        [HttpGet]
        public Stage Get(Stage input)
        {
            return this.stageService.GetValue(input);
        }

        // POST api/<VysorController>
        [HttpPost]
        public void Post([FromBody] Stage input)
        {
            this.stageService.Insert(input);
        }

        // PUT api/<VysorController>/5
        [HttpPut]
        public void Put([FromBody] Stage input)
        {
            this.stageService.Update(input);
        }

        // DELETE api/<VysorController>/5
        [HttpDelete]
        public void Delete([FromBody] Stage input)
        {
            this.stageService.Delete(input);
        }
    }
}
