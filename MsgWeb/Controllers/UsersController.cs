using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using Msg.BLL.AuthenticationServices;
using Msg.Core.ResponseModels;
using Msg.BLL.Interfaces;
using Msg.BLL.BasicServices;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MsgWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ErrorHandlingControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public UsersController(UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                var result = new List<UserViewModel>();
                foreach (var user in users)
                    result.Add(await GetViewModelFromUser(user));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<UserViewModel>>(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUserById(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                return await GetViewModelFromUser(user);
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<UserViewModel>(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Email/{email}")]
        public async Task<ActionResult<UserViewModel>> GetUserByName(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user is null)
                    throw new NullReferenceException();

                return Ok(await GetViewModelFromUser(user));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<UserViewModel>(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]
        [HttpPut]
        public async Task<IActionResult> PutUser(UserModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                user.PhoneNumber = model.Phone;
                user.UserName = model.UserName;
                user.Email = model.Email;

                await _userManager.UpdateAsync(user);
                

                return NoContent();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id));
                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel model)
        {
            try
            {
                if (!ValidateModel(model))
                    return ValidationProblem();

                var user = await _userService.CreateUserAsync(
                    new User()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        PhoneNumber = model.Phone
                    },
                    model.Password,
                    model.Roles
                );

                model.Password = "";
                return Created("", model);
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<UserModel>(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private bool ValidateModel(UserModel model)
        {
            if (model == null || model.Email == "" || model.Phone == "" ||
                model.UserName == "" || model.Password == "")
                return false;
            else
                return true;
        }

        private async Task<UserViewModel> GetViewModelFromUser(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                PacksCount = (user.DevicePacks is null) ? 0 : user.DevicePacks.Count(), 
                Roles = await _userManager.GetRolesAsync(user),
            };
        }

    }
}
