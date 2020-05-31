using Microsoft.AspNetCore.Mvc;
using MontyHall.Model;
using MontyHall.Services;

namespace MontyHall.Controllers
{
    [Route("api/simulation")]
    public class SimulationController : Controller
    {
        private readonly ISimulationService simulationService_;

        public SimulationController(ISimulationService simulationService)
        {
            simulationService_ = simulationService;
        }

        [HttpPost("execute")]
        public SimulationResult Execute([FromBody]SimulationParameters parameters)
        {
            var winRate = simulationService_.Simulate(
                parameters.NumberOfGames, 
                parameters.IsChangeStrategy);

            return new SimulationResult
            {
                WinRate = winRate
            };
        }
    }
}
