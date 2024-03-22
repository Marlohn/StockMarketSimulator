using Microsoft.AspNetCore.Mvc;
using StockMarketSimulator.Users.Kernel.Services;


namespace StockMarketSimulator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

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
