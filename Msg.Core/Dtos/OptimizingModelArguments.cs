using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.Dtos
{
    public class OptimizingModelArguments
    {
        public double D { get; set; }
        public double V { get; set; }
        public PlantModel Plant { get; set; }
        public List<SubstrateModel> Sub { get; set; }
        public BestVariant BestVariant { get; set; } = new BestVariant() { Deviation = int.MaxValue };
    }
}
