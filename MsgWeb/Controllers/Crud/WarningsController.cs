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
    public class WarningsController : ErrorHandlingControllerBase
    {
        private readonly IWarningService _warningService;

        public WarningsController(IWarningService warningService)
        {
            _warningService = warningService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<WarningModel>>> GetUserWarnings(string id)
        {
            try
            {
                var warnings = await _warningService.GetUserWarnings(id);

                return Ok(warnings.Select(GetModelFromWarning));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<List<WarningModel>>(ex);
            }
        }

        [HttpPost("Resolve/{warningId}/User/{userId}")]
        public async Task<ActionResult> ResolveWarning(long warningId, string userId)
        {
            try
            {
                await _warningService.ResolveWarning(userId, warningId);

                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private WarningModel GetModelFromWarning(Warning warning)
        {
            var refPiece = warning.DeviceDataPieces.FirstOrDefault();

            return new WarningModel
            {
                Id = warning.Id,
                IsSolved = warning.IsSolved,
                Date = refPiece.Date,
                DeviceId = refPiece.DeviceId,
                Results = warning.DeviceDataPieces
                    .Select(p => new PropertyModel
                    {
                        DataPieceId = p.DataPieceId,
                        Name = p.DataPiece.Name,
                        Value = p.Value,
                    })
                    .ToList(),
                Required = refPiece.Device.Plant.Characteristics
                    .Select(c => new PropertyModel
                    {
                        DataPieceId = c.DataPieceId,
                        Name = c.DataPiece.Name,
                        Value = c.Value,
                    })
                    .ToList(),

            };
        }
    }
}
