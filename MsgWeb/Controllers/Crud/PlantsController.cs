using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using Msg.DAL;

namespace MsgWeb.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ErrorHandlingControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantsController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        // GET: api/Plants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantModel>>> GetPlants()
        {

            try
            {
                var plants = await _plantService.GetPlantsAsync();
                return Ok(plants.Select(plant => GetModelFromPlant(plant)));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<PlantModel>>(ex);
            }
        }

        // GET: api/Plants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlantById(long id)
        {
            try
            {
                var plant = await _plantService.GetPlantAsync(id);

                return Ok(GetModelFromPlant(plant));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<Plant>(ex);
            }
        }

        // GET: api/Plants/beans
        [HttpGet("{name}")]
        public async Task<ActionResult<Plant>> GetPlantByName(string name)
        {
            try
            {
                var plant = await _plantService.GetPlantAsync(name);

                return Ok(GetModelFromPlant(plant));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<Plant>(ex);
            }
        }

        // PUT: api/Plants/
        [HttpPut]
        public async Task<IActionResult> PutPlant(PlantModel model)
        {
            try
            {
                await _plantService
                    .UpdatePlantAsync(GetPlantFromModel(model));

                return NoContent();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        // POST: api/Plants
        [HttpPost]
        public async Task<ActionResult<long>> PostPlant(PlantModel model)
        {
            try
            {
                return await _plantService
                    .AddPlantAsync(GetPlantFromModel(model));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        // DELETE: api/Plants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(long id)
        {
            try
            {
                await _plantService.DeletePlantAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private PlantModel GetModelFromPlant(Plant plant)
        {
            var model = new PlantModel
            {
                Id = plant.Id,
                Name = plant.Name,
                Description = plant.Description,
                PhotoUrl = plant.PhotoUrl,
                Characteristics = plant.Characteristics.Select(c =>
                    new PropertyModel
                    {
                        Name = c.DataPiece.Name,
                        DataPieceId = c.DataPieceId,
                        Value = c.Value,
                    }).ToList(),
            };

            return model;
        }

        private Plant GetPlantFromModel(PlantModel model)
        {
            var plant = new Plant
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                PhotoUrl = model.PhotoUrl,
                Characteristics = model.Characteristics.Select(c =>
                    new PlantDataPiece
                    {
                        DataPieceId = c.DataPieceId,
                        Value = c.Value,
                    }).ToList(),
            };

            return plant;
        }
    }

}
