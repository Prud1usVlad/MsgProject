using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.BasicServices;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;

namespace MsgWeb.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTypesController : ErrorHandlingControllerBase
    {
        private readonly IDeviceTypeService _deviceTypeService;

        public DeviceTypesController(IDeviceTypeService deviceTypeService)
        {
            _deviceTypeService = deviceTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceTypeModel>>> GetDeviceTypes()
        {

            try
            {
                var deviceTypes = await _deviceTypeService.GetDeviceTypesAsync();
                return Ok(deviceTypes.Select(GetModelFromDeviceType));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<DeviceTypeModel>>(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceTypeModel>> GetDeviceTypeById(long id)
        {
            try
            {
                var deviceType = await _deviceTypeService.GetDeviceTypeAsync(id);

                return Ok(GetModelFromDeviceType(deviceType));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<DeviceTypeModel>(ex);
            }
        }

        [HttpGet("Name/{name}")]
        public async Task<ActionResult<DeviceTypeModel>> GetDeviceTypesByName(string name)
        {
            try
            {
                var deviceType = await _deviceTypeService.GetDeviceTypesAsync(name);

                return Ok(deviceType.Select(GetModelFromDeviceType));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<DeviceTypeModel>(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutDeviceType(DeviceTypeModel model)
        {
            try
            {
                await _deviceTypeService.UpdateDeviceTypeAsync(GetDeviceTypeFromModel(model));

                return NoContent();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<long>> PostDeviceType(DeviceTypeModel model)
        {
            try
            {
                return await _deviceTypeService
                    .AddDeviceTypeAsync(GetDeviceTypeFromModel(model));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceType(long id)
        {
            try
            {
                await _deviceTypeService.DeleteDeviceTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private DeviceTypeModel GetModelFromDeviceType(DeviceType type)
        {
            return new DeviceTypeModel
            {
                Id = type.Id,
                Name = type.Name,
                Description = type.Description,
            };
        }

        private DeviceType GetDeviceTypeFromModel(DeviceTypeModel model)
        {
            return new DeviceType
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };
        }
    }
}
