using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using Msg.Core.ResponseModels;

namespace MsgWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public AuthenticationController(IJwtService jwtService, UserManager<User> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginModel model)
        {
            if (!ValidateModel(model))
                return BadRequest();
            
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user is null)
                return NotFound();

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordValid)
                return ValidationProblem();

            return Ok(_jwtService.CreateToken(user));
        }

        private bool ValidateModel(LoginModel model) =>
            model.Password != "" && model.UserName != "";

    }
}
