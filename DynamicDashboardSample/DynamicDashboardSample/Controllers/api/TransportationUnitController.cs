using DynamicDashboardSample.Domain.Models;
using DynamicDashboardSample.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DynamicDashboardSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationUnitController : ControllerBase
    {
        protected readonly TransportationUnitService transportationUnitService;

        public TransportationUnitController(TransportationUnitService transportationUnitService)
        {
            this.transportationUnitService = transportationUnitService;
        }

        [HttpGet]
        public IEnumerable<TransportationUnit> Get()
        {
            return this.transportationUnitService.GetList();
        }

    }
}
