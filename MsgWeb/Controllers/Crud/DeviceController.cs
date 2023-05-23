using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.BasicServices;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.ResponseModels;
using Msg.Core.RequestModels;

namespace MsgWeb.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ErrorHandlingControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<WarningModel>>> GetDevice(long id)
        {
            try
            {
                var device = await _deviceService.GetDeviceAsync(id);

                return Ok(GetModelFromDevice(device, true));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<List<WarningModel>>(ex);
            }
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult<List<WarningModel>>> GetUserDevices(string id)
        {
            try
            {
                var devices = await _deviceService.GetUserDevicesAsync(id);

                return Ok(devices.Select(e => GetModelFromDevice(e)));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<List<WarningModel>>(ex);
            }
        }

        [HttpPost("ChangePlant/{plantId}/Device/{deviceId}")]
        public async Task<ActionResult> GetUserDevices(long plantId, long deviceId)
        {
            try
            {
                await _deviceService.ChangeDevicePlant(deviceId, plantId);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private DeviceModel GetModelFromDevice(Device device, bool includeDataPieces = false)
        {
            return new DeviceModel
            {
                Id = device.Id,
                Name = device.DeviceType.Name,
                Description = device.DeviceType.Description,
                Image = device.DeviceType.Image,
                DataPieces = (includeDataPieces) ? device.DataPieces.
                    Select(p => new PropertyModel
                    {
                        DataPieceId = p.DataPieceId,
                        Name = p.DataPiece.Name,
                        Value = p.Value,
                    })
                    .ToList() : null,
                Plant = (device.Plant is not null) ? new PlantModel
                {
                    Id = device.Plant.Id,
                    Name = device.Plant.Name,
                    Description = device.Plant.Description,
                    PhotoUrl = device.Plant.PhotoUrl,
                    Characteristics = device.Plant.Characteristics
                        .Select(c => new PropertyModel
                        {
                            DataPieceId = c.DataPieceId,
                            Name = c.DataPiece.Name,
                            Value = c.Value,
                        })
                        .ToList(),
                } : null
                

            };
        }
    }
}
