using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.Interfaces;

namespace MsgWeb.Controllers.Advanced
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ErrorHandlingControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }


        [HttpGet("DevicePack")]
        public async Task<ActionResult<List<Dictionary<string, string>>>> GetDevicePackStatistics() 
        {
            try
            {
                return await _statisticsService.GetDevicePackStatistic();
            }
            catch (Exception ex) 
            {
                return GetProperReturnValue<List<Dictionary<string, string>>>(ex);
            }
        }

        [HttpGet("Orders")]
        public async Task<ActionResult<List<Dictionary<string, string>>>> GetOrdersStatistics()
        {
            try
            {
                return await _statisticsService.GetOrdersStatistic();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<List<Dictionary<string, string>>>(ex);
            }
        }

        [HttpGet("MqttPayload")]
        public async Task<ActionResult<List<Dictionary<string, string>>>> GetMqttPayloadStatistics()
        {
            try
            {
                return await _statisticsService.GetMqttPayloadStatistic();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<List<Dictionary<string, string>>>(ex);
            }
        }
    }
}
