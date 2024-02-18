using DynamicDashboardSample.Domain.Models;
using DynamicDashboardSample.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DynamicDashboardSample.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class VysorStageController : ControllerBase
    {
        protected readonly VysorStageService vysorStageService;

        public VysorStageController(VysorStageService vysorStageService)
        {
            this.vysorStageService = vysorStageService;
        }

        [HttpGet]
        public IEnumerable<VysorStage> GetAll()
        {
            return this.vysorStageService.GetList();
        }

        [HttpGet]
        public IEnumerable<VysorStage> GetListByVysor(int id)
        {
            return this.vysorStageService.GetListByVysor(id);
        }


        [HttpGet]
        public VysorStage Get(VysorStage input)
        {
            return this.vysorStageService.GetValue(input);
        }

        // POST api/<VysorController>
        [HttpPost]
        public void Post([FromBody] VysorStage input)
        {
            this.vysorStageService.Insert(input);
        }

        // PUT api/<VysorController>/5
        [HttpPut]
        public void Put([FromBody] VysorStage input)
        {
            this.vysorStageService.Update(input);
        }

        // DELETE api/<VysorController>/5
        [HttpDelete]
        public void Delete([FromBody] VysorStage input)
        {
            this.vysorStageService.Delete(input);
        }
    }
}
