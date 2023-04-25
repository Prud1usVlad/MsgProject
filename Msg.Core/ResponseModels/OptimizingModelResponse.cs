using Msg.Core.BasicModels;
using Msg.Core.Dtos;
using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.ResponseModels
{
    public class OptimizingModelResponse
    {
        public List<OptimizedSubstrateModel> Result { get; set; }
        public bool IsSucceed { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public double Deviation { get; set; }
        public List<double> res { get; set; }
        public List<double> bestRes { get; set; }
    }
}
