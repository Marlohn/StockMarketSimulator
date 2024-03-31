using Microsoft.AspNetCore.Mvc;
using StockMarketSimulator.Users.Kernel.Models;
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

        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            UserDTO user = await _usersService.Get(userName);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO user)
        {
            await _usersService.Create(user);
            return Ok();
        }

        [HttpPut("{userName}")]
        public async Task<IActionResult> Edit(string userName, [FromBody] UserDTO user)
        {
            return Ok();
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            return Ok();
        }
    }
}
