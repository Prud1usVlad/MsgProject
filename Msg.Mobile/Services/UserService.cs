using Msg.Mobile.Models;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            AuthResponse response = await _httpService
                .PostAsync<AuthResponse, object>(
                    "Authentication/login",
                    new { userName = username, password = password}
                ); 

            Preferences.Default.Set("UserId", response.UserId);
            Preferences.Default.Set("Token", response.Token);

            return true;
        }

        public Task ChangePassword(string userId, string oldPass, string newPass)
        {
            throw new NotImplementedException();
        }

        public Task Forget()
        {
            throw new NotImplementedException();
        }
    }
}
