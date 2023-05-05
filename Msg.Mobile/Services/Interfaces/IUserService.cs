using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> Authenticate(string username, string password);
        public Task Forget();
        public Task ChangePassword(string userId, string oldPass, string newPass);
        public Task ChangeUserData(object data);
    }
}
