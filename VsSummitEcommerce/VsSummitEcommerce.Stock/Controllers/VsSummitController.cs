using Microsoft.AspNetCore.Mvc;

namespace VsSummitEcommerce.Stock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VsSummitController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It's working!");
        }
    }
}
