using Microsoft.AspNetCore.Mvc;

namespace Core.Practice2.Controllers
{
    [Route("api/trolley")]
    public class TrolleyController : Controller
    {
        [HttpGet("trolleyTotal")]
        public IActionResult Index()
        {
            return Ok(0);
        }
    }
}
