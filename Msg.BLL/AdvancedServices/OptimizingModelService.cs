using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.Dtos;
using Msg.Core.RequestModels;
using Msg.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.AdvancedServices
{
    public class OptimizingModelService : IOptimizingModelService
    {
        public async Task<OptimizingModelResponce> GetOptimizedSubstrate(OptimizingModelInput input)
        {
            // TODO needs real implementation
            return new OptimizingModelResponce()
            {
                Price = 23,
                Volume = 5.62,
                Results = new List<OptimizedSubstrateModel>
                {
                    new OptimizedSubstrateModel
                    {
                        Substrate = new SubstrateModel { Name = "Substrate 1", Price = 2, Volume = 4 },
                        PacksAmount = 2,
                        Volume = 6,
                    },
                    new OptimizedSubstrateModel
                    {
                        Substrate = new SubstrateModel { Name = "Substrate 2", Price = 4, Volume = 2 },
                        PacksAmount = 1,
                        Volume = 1.8,
                    }
                }
            };
        }
    }
}
