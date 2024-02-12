using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRTest.Data;
using SignalRTest.Models;

namespace SignalRTest.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController(AppDbContext dbContext) : ControllerBase
    {
        private readonly AppDbContext _dbContext = dbContext;
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user != null)
            {
                return BadRequest("Username already exists");
            }

            var newUser = new Users
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin request)
        {
            var user = await _dbContext.Users
                                       .FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }

            if (user.Password != request.Password)
            {
                return BadRequest("Invalid credentials");
            }

            return Ok(user);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }
    }
}
