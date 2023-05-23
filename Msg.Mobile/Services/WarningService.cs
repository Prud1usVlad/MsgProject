using Msg.Mobile.Models;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services
{
    public class WarningService : IWarningService
    {
        private readonly IHttpService _httpService;

        public WarningService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Warning>> GetWarningsAsync()
        {
            var userId = Preferences.Default.Get("UserId", "none");
            return await _httpService.GetAsync<List<Warning>>("Warnings/" + userId);
        }

        public async Task ResolveWarningAsync(long warningId)
        {
            var userId = Preferences.Default.Get("UserId", "none");
            await _httpService.PostAsync($"Warnings/Resolve/{warningId}/User/{userId}");
        }
    }
}
