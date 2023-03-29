using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using Msg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.BasicServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> CreateUserAsync(User user, string password, IEnumerable<string> roles)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.Aggregate("Errors: \n", (a, e) => a + e.Description + "\n"));

            await AddUserRoles(user.UserName, roles, true);

            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        private async Task AddUserRoles(string userName, IEnumerable<string> roles, bool deleteUserOnError = false)
        {
            var user = await _userManager.FindByNameAsync(userName);

            try
            {
                if (roles.Count() != 0)
                    await _userManager.AddToRolesAsync(user, roles);
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
