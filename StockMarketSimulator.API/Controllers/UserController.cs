using Microsoft.AspNetCore.Mvc;

namespace StockMarketSimulator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid userId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid userId)
        {
            return Ok();
        }
    }
}
