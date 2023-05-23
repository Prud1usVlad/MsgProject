using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Msg.Mobile.Models;

namespace Msg.Mobile.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IHttpService _httpService;

        public DeviceService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task ChangeDevicePlant(long deviceId, long plantId)
        {
            await _httpService.PostAsync($"Device/ChangePlant/{plantId}/Device/{deviceId}");
        }

        public async Task<SystemDevice> GetDeviceInfo(long deviceId)
        {
            return await _httpService.GetAsync<SystemDevice>("Device/" + deviceId);
        }

        public async Task<List<SystemDevice>> GetUserDevices()
        {
            var userId = Preferences.Default.Get("UserId", "none");
            return await _httpService.GetAsync<List<SystemDevice>>("Device/User/" + userId);
        }
    }
}
