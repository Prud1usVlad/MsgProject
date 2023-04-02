using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IStatisticsService
    {
        public Task<List<Dictionary<string, string>>> GetDevicePackStatistic();
        public Task<List<Dictionary<string, string>>> GetOrdersStatistic();

        //public Task<List<Dictionary<string, string>>> GetWarningStatistic();

        public Task<List<Dictionary<string, string>>> GetMqttPayloadStatistic();
    }
}
