using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(IUserService _service) : ControllerBase
    {
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDto dt)
        {
              await _service.Signup(dt);
                return Ok(new { msg = "user register successfully" });

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            
                var token = await _service.Login(dto);
                
  Console.WriteLine("Controller: Service returned");
    Console.WriteLine($"Token = {token}");

                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddMinutes(60)
                });
                Console.WriteLine("Controller: Cookie added");
               return Ok("Login successfull");
            
           
        }
    }

}
