using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.ResponseModels
{
    public class OptimizingModelResponce
    {
        public List<OptimizedSubstrateModel> Results { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
    }
}
