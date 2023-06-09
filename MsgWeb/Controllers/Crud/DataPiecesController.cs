using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.Enums;
using Msg.Core.ResponseModels;


namespace MsgWeb.Controllers.Crud
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DataPiecesController : ErrorHandlingControllerBase
    {
        private readonly IDataPieceService _dataPieceService;

        public DataPiecesController(IDataPieceService dataPieceService)
        {
            _dataPieceService = dataPieceService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataPieceViewModel>> GetDataPiece(long id)
        {
            try
            {
                var dataPiece = await _dataPieceService.GetDataPieceAsync(id);
                return Ok(GetModelFromDataPiece(dataPiece));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<DataPieceViewModel>(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataPieceViewModel>>> GetDataPieces()
        {
            try
            {
                var dataPieces = await _dataPieceService.GetDataPiecesAsync();
                return Ok(dataPieces.Select(GetModelFromDataPiece));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<DataPieceViewModel>>(ex);
            }
        }

        [HttpGet("Name/{name}")]
        public async Task<ActionResult<IEnumerable<DataPieceViewModel>>> GetDataPieces(string name)
        {
            try
            {
                var dataPieces = await _dataPieceService.GetDataPiecesAsync(name);
                return Ok(dataPieces.Select(GetModelFromDataPiece));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<DataPieceViewModel>>(ex);
            }
        }

        [HttpGet("LabelId/{label}")]
        public async Task<ActionResult<IEnumerable<DataPieceViewModel>>> GetDataPieces(DataPieceLabel label)
        {
            try
            {
                var dataPieces = await _dataPieceService.GetDataPiecesAsync(label);
                return Ok(dataPieces.Select(GetModelFromDataPiece));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<DataPieceViewModel>>(ex);
            }
        }

        [HttpGet("PlantRequired")]
        public async Task<ActionResult<IEnumerable<DataPieceViewModel>>> GetPlantsRequiredDataPieces()
        {
            return await GetDataPieces(DataPieceLabel.PlantRequired);
        }

        [HttpGet("SubstrateRequired")]
        public async Task<ActionResult<IEnumerable<DataPieceViewModel>>> GetSubstrateRequiredDataPieces()
        {
            return await GetDataPieces(DataPieceLabel.SubstrateRequired);
        }

        [HttpGet("OptimizingModelRequired")]
        public async Task<ActionResult<IEnumerable<DataPieceViewModel>>> GetOptimizingModelRequiredDataPieces()
        {
            return await GetDataPieces(DataPieceLabel.OptimizingModelRequired);
        }

        [HttpGet("DeviceActionRequired")]
        public async Task<ActionResult<IEnumerable<DataPieceViewModel>>> GetDeviceActionRequiredDataPieces()
        {
            return await GetDataPieces(DataPieceLabel.DeviceActionRequired);
        }

        [HttpPost]
        public async Task<ActionResult<long>> PostDataPice(DataPieceViewModel model)
        {
            try
            {
                return await _dataPieceService
                    .CreateDataPieceAsync(GetDataPieceFromModel(model));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataPice(long id)
        {
            try
            {
                await _dataPieceService.DeleteDataPieceAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private DataPieceViewModel GetModelFromDataPiece(DataPiece dataPiece)
        {
            return new DataPieceViewModel()
            {
                Id = dataPiece.Id,
                Name = dataPiece.Name,
                MeasureUnit = dataPiece.MeasureUnit,
                Labels = dataPiece.DataLabelDataPieces
                    .Select(i => i.DataLabel.Label).ToList(),
            };
        }

        private DataPiece GetDataPieceFromModel(DataPieceViewModel model)
        {
            return new DataPiece() 
            {
                Id = model.Id,
                Name = model.Name,
                MeasureUnit = model.MeasureUnit,
                DataLabelDataPieces = _dataPieceService
                    .GetDataLabelDataPieces(model.Labels, model.Id),
            };
        }
    }
}
