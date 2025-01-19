
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stock_Market_WebAPI.Dtos.User;
using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly UserManager<AddUser> _userManager;

        public UserController(UserManager<AddUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto userDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = new AddUser
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email
                };
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                   var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User created successfully");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
