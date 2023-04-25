using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msg.BLL.Interfaces;
using Msg.Core.Dtos;
using Msg.Core.ResponseModels;

namespace MsgWeb.Controllers.Advanced
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimizingModelController : ErrorHandlingControllerBase
    {
        private readonly IOptimizingModelService _optimizingModelService;

        public OptimizingModelController(IOptimizingModelService optimizingModelService)
        {
            _optimizingModelService = optimizingModelService;
        }

        [HttpPost]
        public async Task<ActionResult<OptimizingModelResponse>> OptimizeChoice(OptimizingModelInput optimizingModelInput)
        {
            try
            {
                return await _optimizingModelService.Optimize(optimizingModelInput);
            }
            catch (Exception ex)
            {
                return GetProperReturnValue<OptimizingModelResponse>(ex);
            }
        }
    }
}
