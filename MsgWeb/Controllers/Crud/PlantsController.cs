﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin, User")]
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

        [Authorize(Roles = "Admin, User")]
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

        [Authorize(Roles = "Admin, User")]
        [HttpGet("Name/{name}")]
        public async Task<ActionResult<Plant>> GetPlantByName(string name)
        {
            try
            {
                var plants = await _plantService.GetPlantsAsync(name);

                return Ok(plants.Select(GetModelFromPlant));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<Plant>(ex);
            }
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
                        PlantId = model.Id,
                        Value = c.Value,
                    }).ToList(),
            };

            return plant;
        }
    }

}
