using Microsoft.AspNetCore.Mvc;
using ServerASP.Services.Interfaces;

namespace ServerASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : Controller
    {
        private IPositionService positionService;
        public PositionController(IPositionService positionService)
        {
            this.positionService = positionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(positionService.GetAllPositions());
        }
    }
}
