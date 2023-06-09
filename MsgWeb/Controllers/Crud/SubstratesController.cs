﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using System.Data;

namespace MsgWeb.Controllers.Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubstratesController : ErrorHandlingControllerBase
    {
        private readonly ISubstrateService _substrateService;

        public SubstratesController(ISubstrateService substrateService)
        {
            _substrateService = substrateService;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubstrateModel>>> GetSubstrates()
        {

            try
            {
                var substrates = await _substrateService.GetSubstratesAsync();
                return Ok(substrates.Select(GetModelFromSubstrate));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<SubstrateModel>>(ex);
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<ActionResult<SubstrateModel>> GetSubstrateById(long id)
        {
            try
            {
                var substrate = await _substrateService.GetSubstrateAsync(id);

                return Ok(GetModelFromSubstrate(substrate));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<SubstrateModel>(ex);
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("Name/{name}")]
        public async Task<ActionResult<SubstrateModel>> GetSubstrateByName(string name)
        {
            try
            {
                var substrates = await _substrateService.GetSubstratesAsync(name);

                return Ok(substrates.Select(GetModelFromSubstrate));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<SubstrateModel>(ex);
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("Filtre")]
        public async Task<ActionResult<IEnumerable<SubstrateModel>>> FiltreSubstrates(SubstrateFilterModel filtre)
        {
            try
            {
                var substrates = await _substrateService.GetSubstratesAsync(filtre);

                return Ok(substrates.Select(GetModelFromSubstrate));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<IEnumerable<SubstrateModel>>(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> PutSubstrate(SubstrateModel model)
        {
            try
            {
                await _substrateService.UpdateSubstrateAsync(GetSubstrateFromModel(model));

                return NoContent();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<long>> PostSubstrate(SubstrateModel model)
        {
            try
            {
                return await _substrateService
                    .AddSubstrateAsync(GetSubstrateFromModel(model));
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubstrate(long id)
        {
            try
            {
                await _substrateService.DeleteSubstrateAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetProperReturnValue(ex);
            }
        }

        private SubstrateModel GetModelFromSubstrate(Substrate substrate)
        {
            var model = new SubstrateModel
            {
                Id = substrate.Id,
                Name = substrate.Name,
                Description = substrate.Description,
                PhotoUrl = substrate.PhotoUrl,
                Price = substrate.Price,
                Volume = substrate.Volume,
                Characteristics = substrate.Characteristics.Select(c =>
                    new PropertyModel
                    {
                        Name = c.DataPiece.Name,
                        DataPieceId = c.DataPieceId,
                        Value = c.Value,
                    }).ToList(),
            };

            return model;
        }

        private Substrate GetSubstrateFromModel(SubstrateModel model)
        {
            var substrate = new Substrate
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                PhotoUrl = model.PhotoUrl,
                Price = model.Price,
                Volume = model.Volume,
                Characteristics = model.Characteristics.Select(c =>
                    new SubstrateDataPiece
                    {
                        DataPieceId = c.DataPieceId,
                        SubstrateId = model.Id,
                        Value = c.Value,
                    }).ToList(),
            };

            return substrate;
        }
    }
}
