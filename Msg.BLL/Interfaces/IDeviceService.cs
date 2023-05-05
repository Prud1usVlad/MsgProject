using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IDeviceService
    {
        public Task<List<Device>> GetDevicesAsync();
        public Task<List<Device>> GetUserDevicesAsync(string userId);
        public Task<Device> GetDeviceAsync(long id);
        public Task ChangeDevicePlant(long deviceId, long plantId);
    }
}
