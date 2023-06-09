using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IDeviceTypeService
    {
        public Task<DeviceType> GetDeviceTypeAsync(long id);
        public Task<List<DeviceType>> GetDeviceTypesAsync(string name);
        public Task<List<DeviceType>> GetDeviceTypesAsync();
        public Task<long> AddDeviceTypeAsync(DeviceType type);
        public Task UpdateDeviceTypeAsync(DeviceType type);
        public Task DeleteDeviceTypeAsync(long id);
    }
}
