using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IPlantService
    {
        public Task<Plant> GetPlantAsync(long id);
        public Task<Plant> GetPlantAsync(string name);
        public Task<List<Plant>> GetPlantsAsync();
        public Task<long> AddPlantAsync(Plant plant);
        public Task UpdatePlantAsync(Plant plant);
        public Task DeletePlantAsync(long id);
    }
}
