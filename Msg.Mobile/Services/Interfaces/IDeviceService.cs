using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Msg.Mobile.Models;

namespace Msg.Mobile.Services.Interfaces
{
    public interface IDeviceService
    {
        public Task<List<SystemDevice>> GetUserDevices();
        public Task<SystemDevice> GetDeviceInfo(long deviceId);
        public Task ChangeDevicePlant(long deviceId, long plantId);
    }
}
