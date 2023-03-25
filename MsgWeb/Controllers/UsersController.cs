using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using Msg.BLL.AuthenticationServices;
using Msg.Core.ResponseModels;

namespace MsgWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<UserCreateModel>> PostUser(UserCreateModel model)
        {
            try
            {
                if (!ValidateModel(model))
                    return ValidationProblem();

                var result = await _userManager.CreateAsync(
                    new User() { UserName = model.UserName, Email = model.Email },
                    model.Password);

                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                await AddUserRoles(model, true);

                model.Password = "";
                return Created("", model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool ValidateModel(UserCreateModel model)
        {
            if (model == null || model.Email == "" || 
                model.UserName == "" || model.Password == "")
                return false;
            else
                return true;
        }

        private async Task AddUserRoles(UserCreateModel model, bool deleteUserOnError = false)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            try
            {
                if (model.Roles.Count != 0)
                    await _userManager.AddToRolesAsync(user, model.Roles);
                else
                    await _userManager.AddToRoleAsync(user, "User");
            }
            catch 
            {
                if (deleteUserOnError)
                    await _userManager.DeleteAsync(user);
            }
        }

    }
}
