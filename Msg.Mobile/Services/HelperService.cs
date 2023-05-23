using Msg.Mobile.Models;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services
{
    public class HelperService : IHelperService
    {
        private readonly IHttpService _httpService;

        public HelperService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HelperResult> UseOptimizingModel(HelperInput input)
        {
            return await _httpService.PostAsync<HelperResult, HelperInput>("OptimizingModel", input);
        }
    }
}
