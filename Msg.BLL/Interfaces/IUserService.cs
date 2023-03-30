using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUserAsync(User user, string password, IEnumerable<string> roles);
        public Task<List<User>> GetUsersAsync();
    }
}
