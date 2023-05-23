using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.BasicServices;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using System.Data;

namespace MsgWeb.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackTypesController : ErrorHandlingControllerBase
    {
        private readonly IPackTypeService _packTypeService;

        public PackTypesController(IPackTypeService packTypeService)
        {
            _packTypeService = packTypeService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackTypeModel>>> GetPackTypes()
        {

            try
            {
                var types = await _packTypeService.GetPackTypesAsync();
                return Ok(types.Select(GetModelFromPackType));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<PackTypeModel>>(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackTypeModel>> GetPackTypeById(long id)
        {
            try
            {
                var packType = await _packTypeService.GetPackTypeAsync(id);

                return Ok(GetModelFromPackType(packType));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<PackTypeModel>(ex);
            }
        }

        [HttpGet("Name/{name}")]
        public async Task<ActionResult<PackTypeModel>> GetPackTypesByName(string name)
        {
            try
            {
                var packType = await _packTypeService.GetPackTypesAsync(name);

                return Ok(packType.Select(GetModelFromPackType));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<PackTypeModel>(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> PutPackType(PackTypeModel model)
        {
            try
            {
                await _packTypeService.UpdatePackTypeAsync(GetPackTypeFromModel(model));

                return NoContent();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<long>> PostPackType(PackTypeModel model)
        {
            try
            {
                return await _packTypeService
                    .AddPackTypeAsync(GetPackTypeFromModel(model));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackType(long id)
        {
            try
            {
                await _packTypeService.DeletePackTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private PackTypeModel GetModelFromPackType(PackType type)
        {
            return new PackTypeModel
            {
                Id = type.Id,
                Name = type.Name,
                Description = type.Description,
                Price = type.Price,
                Image = type.Image,
                DevicesInPack = type.DevicesInPack.Select(d =>
                    new DeviceInPackModel
                    {
                        Id = d.DeviceTypeId,
                        Name = d.DeviceType.Name,
                        Description = d.DeviceType.Description,
                        Amount = d.Amount,
                        Image = d.DeviceType.Image,
                    }).ToList()
            };
        }

        private PackType GetPackTypeFromModel(PackTypeModel model)
        {
            return new PackType
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Image = model.Image,
                DevicesInPack = model.DevicesInPack.Select(d =>
                    new DeviceInPack
                    {
                        DeviceTypeId = d.Id,
                        PackTypeId = model.Id,
                        Amount = d.Amount,
                    }).ToList()
            };
        }
    }
}
