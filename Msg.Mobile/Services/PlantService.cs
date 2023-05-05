using Msg.Mobile.Models;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services
{
    public class PlantService : IPlantService
    {
        private readonly IHttpService _httpService;

        public PlantService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Plant>> GetPlants()
        {
            return await _httpService.GetAsync<List<Plant>>("Plants");            
        }
    }
}
