using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.DTOs.User;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace backend.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO dTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Console.WriteLine(dTO.UserName);
                Console.WriteLine(dTO.Email);
                var appUser = new AppUser
                {
                    UserName = dTO.UserName,
                    Email = dTO.Email,
                };
                var createdUser = await _userManager.CreateAsync(appUser, dTO.Password);
                Console.WriteLine(createdUser);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User created");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500,ex.Message);
            }
        }

    }
}