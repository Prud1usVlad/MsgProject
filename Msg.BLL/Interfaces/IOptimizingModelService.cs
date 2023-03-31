using Msg.Core.BasicModels;
using Msg.Core.Dtos;
using Msg.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IOptimizingModelService
    {
        public Task<OptimizingModelResponce> GetOptimizedSubstrate(OptimizingModelInput input);
    }
}
